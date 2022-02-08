using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace zad1.DataLayer
{
    public class Db
    {
        private static Db _db;
        public static Db Instance
        {
            get
            {
                if (_db == null)
                {
                    _db = new Db();
                }
                return _db;
            }
        }

        public PERSON GetPersonWithId(int id)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                var person = ctx.PERSON.SingleOrDefault(p => p.id == id);
                return person;
            }
        }

        public List<PERSON> GetPersons(int page, string sort, string sortdir)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                var persons = new List<PERSON>();
                if (sortdir.ToLower() == "asc")
                {
                    if (sort.ToLower() == "name")
                    {
                        persons = ctx.PERSON.OrderBy(p => p.name).Skip((page - 1) * 10).Take(10).ToList();
                    }
                    else if (sort.ToLower() == "surname")
                    {
                        persons = ctx.PERSON.OrderBy(p => p.surname).Skip((page - 1) * 10).Take(10).ToList();
                    }
                    else
                    {
                        persons = ctx.PERSON.Skip((page - 1) * 10).Take(10).ToList();
                    }
                }
                else
                {
                    if (sort.ToLower() == "name")
                    {
                        persons = ctx.PERSON.OrderByDescending(p => p.name).Skip((page - 1) * 10).Take(10).ToList();
                    }
                    else if (sort.ToLower() == "surname")
                    {
                        persons = ctx.PERSON.OrderByDescending(p => p.surname).Skip((page - 1) * 10).Take(10).ToList();
                    }
                    else
                    {
                        persons = ctx.PERSON.Skip((page - 1) * 10).Take(10).ToList();
                    }
                }

                return persons;
            }
        }

        public int GetPersonsCount()
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                var count = ctx.PERSON.Count();
                return count;
            }
        }

        public void AddPerson(string name, string surname)
        {
            var person = new PERSON()
            {
                name = name,
                surname = surname
            };
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                ctx.PERSON.InsertOnSubmit(person);
                ctx.SubmitChanges();
            }
        }

        public void UpdatePerson(int id, string name, string surname)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                var person = ctx.PERSON.SingleOrDefault(p => p.id == id);
                person.name = name;
                person.surname = surname;
                ctx.SubmitChanges();
            }
        }

        public void DeletePersonWithId(int id)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                var personToDelete = ctx.PERSON.SingleOrDefault(p => p.id == id);
                ctx.PERSON.DeleteOnSubmit(personToDelete);
                ctx.SubmitChanges();
            }
        }
    }
}