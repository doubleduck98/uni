using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace zad1
{
    public partial class SimpleContainer
    {
        private class SimpleFactory
        {
            private readonly Type _type;
            private readonly bool _singleton;
            private object _instance;

            public SimpleFactory(Type type, bool singleton)
            {
                _type = type;
                _singleton = singleton;
            }

            public SimpleFactory(Type type, object instance)
            {
                _type = type;
                _singleton = true;
                _instance = instance;
            }

            public object Instance(Dictionary<Type, SimpleFactory> register)
            {
                if (_singleton)
                {
                    return _instance ?? (_instance = ResolveInstance(register, new List<Type>()));
                }

                return ResolveInstance(register, new List<Type>());
            }

            private ConstructorInfo GetConstructor()
            {
                if (HasNoConstuctors(_type))
                {
                    throw new DependencyResolveException(
                        $"Type {_type.FullName} has no constructors, therfore cannot be resolved.");
                }

                var constructors = _type
                    .GetConstructors()
                    .Where(ci =>
                    {
                        return ci
                            .GetCustomAttributes().ToList()
                            .Exists(attribute => attribute.GetType() == typeof(DependencyConstructor));
                    }).ToList();
                if (constructors.Count > 1)
                {
                    throw new DependencyAttributeException(
                        $"More than one constructor is marked with attribute {nameof(DependencyConstructor)}.");
                }

                var constructor = constructors.FirstOrDefault();
                if (constructor != null)
                {
                    return constructor;
                }

                var maxArgs = _type
                    .GetConstructors()
                    .Max(ci => ci.GetParameters().Length);
                // rozwikłujemy którykolwiek konstruktor, tutaj pierwszy
                constructor = _type
                    .GetConstructors()
                    .FirstOrDefault(ci => ci.GetParameters().Length == maxArgs);
                return constructor;
            }

            private object ResolveInstance(
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved)
            {
                resolved.Add(_type);
                var constructor = GetConstructor();
                Debug.Assert(constructor != null);
                var parameters = ResolveParameters(constructor, register, resolved);
                return constructor.Invoke(parameters.ToArray());
            }

            private static List<object> ResolveParameters(
                ConstructorInfo constructor,
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved)
            {
                return constructor
                    .GetParameters()
                    .Select(parameter => ResolveParameter(parameter, register, resolved))
                    .ToList();
            }

            private static object ResolveParameter(
                ParameterInfo parameter,
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved)
            {
                var type = parameter.ParameterType;
                if (resolved.Contains(type))
                {
                    throw new DependencyResolveException("Cycle in dependency tree.");
                }

                if (type.IsInterface || type.IsAbstract)
                {
                    if (!register.ContainsKey(type))
                    {
                        throw new DependencyNotRegisteredException($"Type {type.FullName} is not registered.");
                    }
                }

                return register.ContainsKey(type)
                    ? register[type].Instance(register)
                    : new SimpleFactory(type, false).ResolveInstance(register, resolved);
            }

            private static bool HasNoConstuctors(Type type)
            {
                return !type.GetConstructors().Any();
            }

            private static bool HasParameterlessConstructor(Type type)
            {
                return type.GetConstructors().Any(ci => ci.GetParameters().Length == 0);
            }
        }
    }
}