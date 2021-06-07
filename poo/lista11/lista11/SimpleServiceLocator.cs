using System;

namespace lista11
{
    public delegate SimpleContainer ContainerProviderDelegate();

    public class SimpleServiceLocator
    {
        private static SimpleServiceLocator _currrent;
        private static ContainerProviderDelegate _container;

        public static void SetContainerProvider(ContainerProviderDelegate containerProvider)
        {
            _container = containerProvider;
        }

        public static SimpleServiceLocator Current => _currrent ?? (_currrent = new SimpleServiceLocator());

        public T GetInstance<T>()
        {
            if (_container == null)
            {
                throw new ArgumentNullException(nameof(_container), "Container provider is not set.");
            }

            if (typeof(T) == typeof(SimpleContainer))
            {
                return (T) (object) _container.Invoke();
            }

            return _container.Invoke().Resolve<T>();
        }
    }
}