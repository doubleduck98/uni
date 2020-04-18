using System;

namespace zadanie1._4._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var wordType = Type.GetTypeFromProgID("Word.Application");
            dynamic w = Activator.CreateInstance(wordType);
            w.Visible = true;
            var doc = w.Documents.Add();
            doc.Range().Text = "Programowanie pod Windows";
            // domyślna ścieżka zapisu /user/Dokumenty 
            doc.SaveAs("ppw.doc");
        }
    }
}