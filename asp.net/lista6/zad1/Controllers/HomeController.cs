using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zad1.Models;
using zad1.DataLayer;

namespace zad1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int page = 1, string sort = "", string sortdir = "")
        {
            var model = new IndexModel();
            var data = Db.Instance;
            model.Persons = new PagedEnumerable<PERSON>
            {
                CurrentPage = page,
                PageSize = 10,
                TotalCount = data.GetPersonsCount(),
                Items = data.GetPersons(page, sort, sortdir)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddModel model)
        {
            if (ModelState.IsValid)
            {
                Db.Instance.AddPerson(model.Name, model.Surname);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
            var person = Db.Instance.GetPersonWithId(id);
            var model = new EditModel()
            {
                Id = id,
                Name = person.name,
                Surname = person.surname
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                Db.Instance.UpdatePerson(model.Id, model.Name, model.Surname);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id = 1)
        {
            var person = Db.Instance.GetPersonWithId(id);
            var model = new DeleteModel()
            {
                Id = id,
                Name = person.name,
                Surname = person.surname
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteModel model)
        {
            Db.Instance.DeletePersonWithId(model.Id);
            return RedirectToAction("Index");
        }
    }
}