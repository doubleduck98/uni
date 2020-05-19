using System;
using System.Collections.Generic;
using System.Globalization;

namespace zadanie2._3._8
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var jezyki = new List<string>() {"en-GB", "de-DE", "fr-FR", "ru-RU", "ar-SA", "cs-CZ", "pl-PL"};
            foreach (var j in jezyki)
            {
                var ci = new CultureInfo(j, false);
                Console.WriteLine("{0}: {1}", ci.Name, ci.DisplayName);
                foreach (var n in ci.DateTimeFormat.MonthNames)
                {
                    Console.Write(n +" ");
                }
                Console.WriteLine();
                foreach (var n in ci.DateTimeFormat.AbbreviatedMonthNames)
                {
                    Console.Write(n +" ");
                }
                Console.WriteLine();
                foreach (var n in ci.DateTimeFormat.DayNames)
                {
                    Console.Write(n +" ");
                }
                Console.WriteLine();
                foreach (var n in ci.DateTimeFormat.AbbreviatedDayNames)
                {
                    Console.Write(n +" ");
                }
                Console.WriteLine();
                Console.WriteLine(DateTime.Now.ToString(ci));
                Console.WriteLine("***");
            }
        }
    }
}