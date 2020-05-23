using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Xml.Schema;

namespace zadanie2._5._4
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var cs = @"server=.\sqlexpress;database=efExample;integrated security=true";
            using (var ctx = new MiejscowoscStudentContext(cs))
            {
                var nMiejscowosc = new Miejscowosc() {Nazwa = "Tarnobrzeg"};
                ctx.Miejscowosc.Add(nMiejscowosc);
                ctx.SaveChanges();

                var nStudent = new Student()
                {
                    Imię = "Szymon",
                    Nazwisko = "Zienkiewicz",
                    DataUrodzenia = new DateTime(1998, 11, 16),
                    Miejscowosc = nMiejscowosc
                };
                ctx.Student.Add(nStudent);
                ctx.SaveChanges();

                var query = ctx.Student.Join(
                    ctx.Miejscowosc,
                    s => s.Miejscowosc,
                    m => m,
                    (s, m) => new {s.Imię, s.Nazwisko, s.DataUrodzenia, m.Nazwa});
                foreach (var stud in query)
                {
                    Console.WriteLine("{0} {1} {2} {3}", stud.Imię, stud.Nazwisko, stud.DataUrodzenia, stud.Nazwa);
                }

                var query2 = ctx.Miejscowosc.ToList();
                foreach (var miejsc in query2)
                {
                    if (miejsc.Nazwa == "Tarnobrzeg")
                    {
                        miejsc.Nazwa = "Wrocław";
                    }

                    ctx.SaveChanges();
                }

                var query3 = ctx.Student.ToList();
                foreach (var stud in query3)
                {
                    if (stud.Imię == "Szymon")
                    {
                        ctx.Student.Remove(stud);
                    }

                    ctx.SaveChanges();
                }
            }
        }
    }

    public class MiejscowoscStudentContext : DbContext
    {
        public MiejscowoscStudentContext()
        {
        }

        public MiejscowoscStudentContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Miejscowosc> Miejscowosc { get; set; }
    }


    public class Student
    {
        public int Id { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public virtual Miejscowosc Miejscowosc { get; set; }
    }


    public class Miejscowosc
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public virtual ICollection<Student> Studenci { get; set; }
    }
}