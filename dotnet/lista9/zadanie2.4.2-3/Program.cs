using System;
using System.Xml;
using System.Xml.Schema;

namespace zadanie2._4._2
{
    internal static class Program
    {
        private static void ValidationHandler(object sender, ValidationEventArgs args)
        {
            Console.WriteLine("Błąd walidacji!");
            Console.WriteLine("\tWaznosc: {0}", args.Severity);
            Console.WriteLine("\tInfo: {0}", args.Message);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Pierwszy dokument:");
            var xml = new XmlDocument();
            var tr = new XmlTextReader("ListaStudentow.xml");
            var reader = new XmlValidatingReader(tr) {ValidationType = ValidationType.Schema};
            reader.ValidationEventHandler += ValidationHandler;
            xml.Load(reader);
            Console.WriteLine("Dokument poprawny!");
            Console.WriteLine("***");
            Console.WriteLine("Drugi dokument:");
            tr = new XmlTextReader("ZlaListaStudentow.xml");
            reader = new XmlValidatingReader(tr) {ValidationType = ValidationType.Schema};
            reader.ValidationEventHandler += ValidationHandler;
            xml.Load(reader);
        }
    }
}