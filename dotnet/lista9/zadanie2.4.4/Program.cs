using System;
using System.IO;
using System.Xml.Serialization;

namespace zadanie2._4._4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var xmls = new XmlSerializer(typeof(ListaStudentowType));
            var fs = new FileStream("ListaStudentow.xml", FileMode.Open);
            var listaStudentow = (ListaStudentowType) xmls.Deserialize(fs);
            foreach (var student in listaStudentow.Student)
            {
                Console.WriteLine($"{student.Imie} {student.Nazwisko}");
                Console.Write($"{student.Adres.Ulica} {student.Adres.NrDomu}");
                if (student.Adres.MieszkanieSpecified)
                {
                    Console.WriteLine($"/{student.Adres.Mieszkanie}");
                }
                else
                {
                    Console.WriteLine();
                }
                Console.WriteLine($"{student.Adres.KodPocztowy}, {student.Adres.Miasto}");
            }
        }
    }
}