using System;
using System.Linq;

namespace zadanie2._5._3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var cs = @"server=.\sqlexpress;database=example;integrated security=true";
            using (var db = new ExampleDataContext(cs))
            {
                var nMiejscowosc = new Miejscowosc()
                {
                    Nazwa = "Tarnobrzeg"
                };
                db.Miejscowosc.InsertOnSubmit(nMiejscowosc);
                db.SubmitChanges();
                var nStudent = new Student()
                {
                    Imię = "Szymon",
                    Nazwisko = "Zienkiewicz",
                    DataUrodzenia = new DateTime(1998, 11, 16),
                    Miejscowosc = nMiejscowosc.id
                };
                db.Student.InsertOnSubmit(nStudent);
                db.SubmitChanges();

                foreach (var stud in (from s in db.Student
                                      join m in db.Miejscowosc
                                      on s.Miejscowosc equals m.id
                                      select new {s.Imię, s.Nazwisko, s.DataUrodzenia, m.Nazwa}))
                {
                    Console.WriteLine("{0} {1} {2} {3}", stud.Imię, stud.Nazwisko, stud.DataUrodzenia, stud.Nazwa);
                }

                foreach (var miejsc in db.Miejscowosc)
                {
                    if (miejsc.Nazwa == "Tarnobrzeg")
                    {
                        miejsc.Nazwa = "Wrocław";
                    }
                }
                db.SubmitChanges();

                foreach (var stud in db.Student)
                {
                    if(stud.Nazwisko == "Zienkiewicz")
                    {
                        db.Student.DeleteOnSubmit(stud);
                    }
                }
                db.SubmitChanges();
            }

        }
    }
}