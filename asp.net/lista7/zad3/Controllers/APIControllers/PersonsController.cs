﻿using System.Web.Http;
using zad3.DataLayer;

namespace zad3.Controllers.APIControllers
{
    [JWTAuthenticationFilter]
    public class PersonsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var people = Db.Instance.GetPersons();
            return Ok(people);
        }

        public IHttpActionResult Get(int id)
        {
            var person = Db.Instance.GetPersonWithId(id);
            return Ok(person);
        }

        public IHttpActionResult Post(string name, string surname)
        {
            var person = new PERSON()
            {
                name = name,
                surname = surname
            };
            var nPerson = Db.Instance.AddPerson(person);
            return Ok(nPerson);
        }

        public IHttpActionResult Post(PERSON person)
        {
            var nPerson = Db.Instance.AddPerson(person);
            return Ok(nPerson);
        }
    }
}