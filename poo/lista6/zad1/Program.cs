using System;
using System.IO;

namespace zad1
{
    public interface ILogger
    {
        void Log(string message);
    }

    public enum LogType
    {
        None,
        Console,
        File
    }

    public class NullLogger : ILogger
    {
        public void Log(string message)
        {
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentException("path can not be null");
        }

        public void Log(string message)
        {
            using (var sw = File.AppendText(_filePath))
            {
                sw.WriteLine(message);
            }
        }
    }

    public class LoggerFactory
    {
        private static LoggerFactory _instance;

        public static ILogger GetLogger(LogType logType, string parameters = null)
        {
            switch (logType)
            {
                case LogType.None:
                    return new NullLogger();
                case LogType.Console:
                    return new ConsoleLogger();
                case LogType.File:
                    return new FileLogger(parameters);
                default:
                    throw new ArgumentOutOfRangeException(nameof(logType), logType, null);
            }
        }

        public static LoggerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoggerFactory();
                }

                return _instance;
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var logger1 = LoggerFactory.GetLogger(LogType.File, "foo.txt");
            logger1.Log("foo bar"); // logowanie do pliku
            var logger2 = LoggerFactory.GetLogger(LogType.None);
            logger2.Log("qux"); // brak logowania
            var logger3 = LoggerFactory.GetLogger(LogType.Console);
            logger3.Log("baz"); // logowanie do konsoli
        }
    }
}