using System;
using System.IO;
using System.Linq;

namespace zadanie1._3._4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var nazwyPlikow = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "folder"));
            var dlugosciPlikow = nazwyPlikow.Select(s => new FileInfo(s)).Select(fi => fi.Length).ToList();
            var sumaDlugosci = dlugosciPlikow.Aggregate(0L, (x, y) => x + y);
            Console.WriteLine($"Suma długości plików w katalogu wynosi {sumaDlugosci} bajtów.");
        }
    }
}