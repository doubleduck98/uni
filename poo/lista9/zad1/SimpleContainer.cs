using System;
using System.Collections.Generic;

namespace zad1
{
    public class SimpleContainer
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

            public T Instance<T>()
            {
                if (_singleton)
                {
                    if (_instance == null)
                    {
                        _instance = Activator.CreateInstance(_type);
                    }

                    return (T) _instance;
                }

                return (T) Activator.CreateInstance(_type);
            }
        }

        private readonly Dictionary<Type, SimpleFactory> _register = new Dictionary<Type, SimpleFactory>();
        private readonly Dictionary<Type, Type> _types = new Dictionary<Type, Type>();


        public void RegisterType<T>(bool singleton) where T : class
        {
            _register[typeof(T)] = new SimpleFactory(typeof(T), singleton);
        }

        public void RegisterType<From, To>(bool singleton) where To : From
        {
            _types[typeof(From)] = typeof(To);
            _register[typeof(To)] = new SimpleFactory(typeof(To), singleton);
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            if (typeof(T).IsInterface || typeof(T).IsAbstract)
            {
                if (!_types.ContainsKey(typeof(T)))
                {
                    throw new ArgumentException($"Type {typeof(T)} is not registered.");
                }

                type = _types[typeof(T)];
            }

            if (_register.ContainsKey(type))
            {
                return _register[type].Instance<T>();
            }
            
            return (T) Activator.CreateInstance(typeof(T));
        }
    }
}