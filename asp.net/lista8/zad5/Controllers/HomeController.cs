using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using zad5.DataLayer;
using zad5.Models;

namespace zad5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var db = HttpContext.RequestServices.GetService(typeof(IDapperRepo<Person>)) as DapperRepo<Person>;
            var model = new IndexModel()
            {
                Persons = db.GetTwentyOne()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}