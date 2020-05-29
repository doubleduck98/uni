using System;
using System.Linq;
using System.Xml.Linq;

namespace zadanie2._4._7
{
    internal class Program
    {
        private static string Literka()
        {
            Console.WriteLine("Prosze podać literkę:");
            var literka = Console.ReadLine();
            if (literka?.Length != 1)
            {
                Console.WriteLine("To nie jest literka!");
                Environment.Exit(-1);
            }
            return literka.ToLowerInvariant();
        }
        
        public static void Main(string[] args)
        {
            var listaStudentow = XElement.Load("ListaStudentow.xml");
            var literka = Literka();
            var studenci =
                from stud in listaStudentow.Elements()
                where ((string) stud.Attribute("Nazwisko")).ToLowerInvariant().StartsWith(literka)
                select stud;
            foreach (var student in studenci)
            {
                Console.WriteLine("{0} {1}", student.Attribute("Imie")?.Value, student.Attribute("Nazwisko")?.Value);
                var adres = student.Element(XName.Get("{MojaLista}Adres"));
                if (adres?.Attribute("Mieszkanie") != null)
                {
                    Console.WriteLine("{0} {1}/{2}",
                        adres.Attribute("Ulica")?.Value, adres.Attribute("NrDomu")?.Value,
                        adres.Attribute("Mieszkanie")?.Value);
                }
                else
                {
                    Console.WriteLine("{0} {1}", adres?.Attribute("Ulica")?.Value, adres?.Attribute("NrDomu")?.Value);
                }

                Console.WriteLine("{0}, {1}", adres?.Attribute("KodPocztowy")?.Value, adres?.Attribute("Miasto")?.Value);
            }
        }
    }
}