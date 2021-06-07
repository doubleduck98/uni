using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace lista11
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

            public object Instance(Dictionary<Type, SimpleFactory> register, ICollection<Type> resolved = null)
            {
                if (_singleton)
                {
                    return _instance ?? (_instance = ResolveInstance(register, resolved ?? new List<Type>()));
                }

                return ResolveInstance(register, resolved ?? new List<Type>());
            }

            private object ResolveInstance(
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved)
            {
                resolved.Add(_type);
                var constructor = GetConstructor();
                var parameters = ResolveParameters(constructor, register, resolved);
                var obj = constructor.Invoke(parameters.ToArray());
                if (HasMethodToInject(_type))
                {
                    ResolveMethods(obj, _type, register, resolved);
                }

                resolved.Remove(_type);
                return obj;
            }

            private static IEnumerable<object> ResolveParameters(
                ConstructorInfo constructor,
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved)
            {
                return constructor
                    .GetParameters()
                    .Select(parameter => ResolveParameter(parameter, register, resolved));
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
                        throw new DependencyNotRegisteredException($"Type {type.Name} is not registered.");
                    }
                }

                return register.ContainsKey(type)
                    ? register[type].Instance(register, resolved)
                    : new SimpleFactory(type, false).ResolveInstance(register, resolved);
            }

            public static void ResolveMethods(
                object obj,
                Type type,
                Dictionary<Type, SimpleFactory> register,
                ICollection<Type> resolved = null)
            {
                var methods = GetMethodsToInject(type);
                foreach (var method in methods)
                {
                    if (IsNotInjectable(method))
                    {
                        throw new DependencyAttributeException(
                            $"Method {method.Name} cannot be injected - either is not void or has empty parameter list.");
                    }

                    var parameters = method
                        .GetParameters()
                        .Select(p => ResolveParameter(p, register, resolved ?? new List<Type>()))
                        .ToArray();
                    method.Invoke(obj, parameters);
                }
            }

            private ConstructorInfo GetConstructor()
            {
                if (HasNoConstuctors(_type))
                {
                    throw new DependencyResolveException(
                        $"Type {_type.Name} has no constructors, therefore cannot be resolved.");
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
                constructor = _type
                    .GetConstructors()
                    .FirstOrDefault(ci => ci.GetParameters().Length == maxArgs);
                return constructor;
            }

            private static IEnumerable<MethodInfo> GetMethodsToInject(Type type)
            {
                return type
                    .GetMethods()
                    .Where(mi =>
                    {
                        return mi
                            .GetCustomAttributes()
                            .Any(attribute => attribute.GetType() == typeof(InjectionMethod));
                    });
            }

            private static bool HasNoConstuctors(Type type)
            {
                return !type.GetConstructors().Any();
            }

            private static bool HasMethodToInject(Type type)
            {
                return type.GetMethods().Any(mi =>
                    mi.GetCustomAttributes().Any(attribute => attribute.GetType() == typeof(InjectionMethod)));
            }

            private static bool IsNotInjectable(MethodInfo m)
            {
                return !(m.ReturnType == typeof(void) && m.GetParameters().Any());
            }
        }
    }
}