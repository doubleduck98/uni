using System;
using System.Collections.Generic;

namespace zadanie2._3._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var mojaKolekcja = new Set {7, 8};
            if (mojaKolekcja.Contains(7)) mojaKolekcja.Clear();
            var lista = new List<int>() {2, 4, 6};
            var mojaKolekcja2 = new Set(lista);
            mojaKolekcja.Add(1);
            mojaKolekcja.Add(3);
            mojaKolekcja.Add(5);
            mojaKolekcja.Wypisz();
            Console.WriteLine("***");
            mojaKolekcja.IntersectWith(mojaKolekcja2);
            mojaKolekcja.Wypisz();
            Console.WriteLine("***");
            mojaKolekcja.UnionWith(mojaKolekcja2);
            mojaKolekcja.Wypisz();
            Console.WriteLine("***");
            mojaKolekcja.Remove(4);
            mojaKolekcja.Wypisz();
        }
    }
}