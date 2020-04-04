using System;
using System.IO;
using System.Linq;

namespace zadanie1._3._5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // oba pliki w katalogu Debug
            var osoby = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "osoby.txt"));
            var numery = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "numery.txt"));
            var zbiorOsob = from osoba in osoby
                select new {Imie = osoba.Split(' ')[0], Nazwisko = osoba.Split(' ')[1], PESEL = osoba.Split(' ')[2]};
            var zbiorNumerow = from numer in numery
                select new {PESEL = numer.Split(' ')[0], NrKonta = numer.Split(' ')[1]};
            var combined = from os in zbiorOsob
                join nr in zbiorNumerow on os.PESEL equals nr.PESEL
                select new {os.Imie, os.Nazwisko, os.PESEL, nr.NrKonta};
            foreach (var v in combined)
            {
                Console.WriteLine($"{v.Imie} {v.Nazwisko} {v.PESEL} {v.NrKonta}");
            }
        }
    }
}