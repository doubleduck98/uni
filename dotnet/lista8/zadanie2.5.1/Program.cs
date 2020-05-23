using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace zadanie2._5._1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "excel.xlsx");
            var cs =
                $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES';";
            var listaOsob = new List<Osoba>();

            using (var conn = new OleDbConnection(cs))
            {
                conn.Open();
                var query = "SELECT * FROM [Arkusz1$]";
                using (var command = new OleDbCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaOsob.Add(new Osoba(
                                reader[0].ToString(),
                                reader[1].ToString(),
                                int.Parse(reader[2].ToString())));
                        }
                    }
                }

                conn.Close();
            }

            foreach (var osoba in listaOsob)
            {
                Console.WriteLine(osoba);
            }
        }
    }

    public class Osoba
    {
        private readonly string _imie;
        private readonly string _nazwisko;
        private readonly int _wiek;

        public Osoba(string imie, string nazwisko, int wiek)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _wiek = wiek;
        }

        public override string ToString()
        {
            return $"{_imie} {_nazwisko}, lat {_wiek}";
        }
    }
}