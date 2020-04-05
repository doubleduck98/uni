using System;
using System.IO;
using System.Linq;

namespace zadanie1._3._6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var logFile = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "logi.txt"));
            var logs =
                from log in logFile
                select new
                {
                    Time = log.Split(' ')[0],
                    IP = log.Split(' ')[1],
                    RequestType = log.Split(' ')[2],
                    Address = log.Split(' ')[3],
                    ResponseStatus = log.Split(' ')[4],
                };
                
            var top3 = (
                from log in logs
                group log by log.IP
                into l
                orderby l.Count() descending
                select new
                {
                    IP = l.Key,
                    Count = l.Count()
                }).Take(3);

            foreach (var i in top3)
            {
                Console.WriteLine($"{i.IP} {i.Count}");
            }
        }
    }
}