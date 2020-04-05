using System;
using System.IO;
using System.Linq;

namespace zadanie1._3._3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // plik nazwiska.txt znajduje się w katalogu Debug
            var nazwiska = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "nazwiska.txt"));
            foreach (var nazwisko in nazwiska)
            {
                Console.WriteLine(nazwisko);
            }

            var literki = 
                from nazwisko in nazwiska
                group nazwisko by nazwisko[0]
                into pierwszeLiterki
                orderby pierwszeLiterki.Key
                select pierwszeLiterki.Key;
            
            foreach (var l in literki)
            {
                Console.WriteLine(l);
            }
        }
    }
}