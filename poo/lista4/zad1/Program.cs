using System.Diagnostics;
using System.Threading;

namespace zad1
{
    public class Singleton
    {
        private static Singleton _instance;

        public static Singleton Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    public class ThreadSingleton
    {
        private static ThreadLocal<ThreadSingleton> _threadInstance = new ThreadLocal<ThreadSingleton>();

        public static ThreadSingleton Instance()
        {
            if (!_threadInstance.IsValueCreated)
            {
                _threadInstance.Value = new ThreadSingleton();
            }

            return _threadInstance.Value;
        }
    }

    public class TimedSingleton
    {
        private static TimedSingleton _instance;
        private static Stopwatch _timer;

        public TimedSingleton()
        {
            _timer = new Stopwatch();
        }

        public static TimedSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new TimedSingleton();
                _timer.Start();
            }
            else
            {
                if (_timer.ElapsedMilliseconds >= 5000)
                {
                    _instance = new TimedSingleton();
                    _timer.Restart();
                }
            }

            return _instance;
        }
    }

    internal static class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}