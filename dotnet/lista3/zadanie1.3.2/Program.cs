using System;
using System.IO;
using System.Linq;

namespace zadanie1._3._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // plik liczby.txt znajduje się w katalogu Debug
            var liczby = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "liczby.txt"));
            foreach (var l in
                from liczba in liczby
                where int.Parse(liczba) > 100
                orderby int.Parse(liczba) descending
                select liczba)
            {
                Console.WriteLine(l);
            }

            // w odróżnieniu od sposobu wyżej muszę podawać na przykład lambda wyrażenia 
            foreach (var l in liczby
                .Where(liczba => int.Parse(liczba) > 100)
                .OrderBy(liczba => -int.Parse(liczba)))
            {
                Console.WriteLine(l);
            }
        }
    }
}