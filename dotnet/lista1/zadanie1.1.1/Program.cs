// zadanie 1.1.1

using System;
using System.Collections.Generic;

namespace lista1
{
    static class Program
    {
        static void Prostyalgorytm()
        {
            bool PrzezSume(int num)
            {
                var suma = 0;
                while (num != 0)
                {
                    suma += num % 10;
                    num /= 10;
                }

                return suma != 0 && num % suma == 0;
            }

            bool PrzezKazda(int num)
            {
                while (num != 0)
                {
                    var cyferka = num % 10;
                    if (cyferka == 0 || num % cyferka != 0)
                    {
                        return false;
                    }
                    num /= 10;
                }

                return true;
            }
            
            var res = new List<int>();
            for (var i = 1; i <= 100000; ++i)
            {
                if (PrzezKazda(i) && PrzezSume(i))
                {
                    res.Add(i);
                }
            }

            // foreach (var i in res)
            // {
            //     Console.WriteLine(i);
            // }
            
            Console.WriteLine($"Znaleziono {res.Count} liczb.");
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Zad1: ");
            Prostyalgorytm();
        }
    }
}