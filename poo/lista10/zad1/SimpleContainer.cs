using System;
using System.Collections.Generic;

namespace zad1
{
    public partial class SimpleContainer
    {
        private readonly Dictionary<Type, SimpleFactory> _register = new Dictionary<Type, SimpleFactory>();

        public void RegisterType<T>(bool singleton) where T : class
        {
            _register[typeof(T)] = new SimpleFactory(typeof(T), singleton);
        }

        public void RegisterType<TFrom, TTo>(bool singleton) where TTo : TFrom
        {
            _register[typeof(TFrom)] = new SimpleFactory(typeof(TTo), singleton);
        }

        public void RegisterInstance<T>(T instance)
        {
            _register[typeof(T)] = new SimpleFactory(instance.GetType(), instance);
        }

        public T Resolve<T>()
        {
            if (typeof(T).IsInterface || typeof(T).IsAbstract)
            {
                if (!_register.ContainsKey(typeof(T)))
                {
                    throw new DependencyNotRegisteredException($"Type {typeof(T).FullName} is not registered.");
                }
            }
            
            if (_register.ContainsKey(typeof(T)))
            {
                return (T) _register[typeof(T)].Instance(_register);
            }

            return (T) new SimpleFactory(typeof(T), false).Instance(_register);
        }
    }

    public class DependencyConstructor : Attribute
    {
    }

    public class DependencyNotRegisteredException : Exception
    {
        public DependencyNotRegisteredException(string msg) : base(msg)
        {
        }
    }

    public class DependencyAttributeException : Exception
    {
        public DependencyAttributeException(string msg) : base(msg)
        {
        }
    }

    public class DependencyResolveException : Exception
    {
        public DependencyResolveException(string msg) : base(msg)
        {
        }
    }
}