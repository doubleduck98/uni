using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace zad3.DataLayer
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

        public PERSON AddPerson(PERSON person)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                ctx.PERSON.InsertOnSubmit(person);
                ctx.SubmitChanges();
                return person;
            }
        }
        
        public List<PERSON> GetPersons()
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new PERSONDataContext(cs))
            {
                return ctx.PERSON.ToList();
            }
        }
    }
}