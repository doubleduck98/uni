using System;

namespace lista11
{
    // zad4
    public interface ILogger
    {
        void LogMessage(string msg);
    }

    public class ConsoleLogger : ILogger
    {
        public void LogMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class LoggerFactory
    {
        private static Func<ILogger> _provider;

        public static void SetProvider(Func<ILogger> provider)
        {
            _provider = provider;
        }

        public ILogger Create()
        {
            if (_provider == null)
            {
                throw new ArgumentNullException(nameof(_provider), "Provider is not set.");
            }

            return _provider();
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // composition root
            var container = new SimpleContainer();
            container.RegisterType<ILogger, ConsoleLogger>(true);
            LoggerFactory.SetProvider(() => container.Resolve<ILogger>());

            // application
            var logger = new LoggerFactory().Create();
            logger.LogMessage($"It works! - {logger.GetType()}");
        }
    }
}