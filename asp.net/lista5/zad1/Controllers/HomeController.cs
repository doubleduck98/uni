using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zad1.Models;

namespace zad1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Start");
        }

        [HttpGet]
        public ActionResult Start()
        {
            var model = new StartModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Start(StartModel model)
        {
            if (ModelState.IsValid)
            {
                Session["StartModel"] = model;
                return RedirectToAction("Print");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Print()
        {
            StartModel model = (StartModel) Session["StartModel"];
            if (model == null)
            {
                return RedirectToAction("Start");
            }

            return View(model);
        }
    }
}