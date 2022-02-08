using System.Web.Mvc;

namespace zad3.Controllers.MVCControllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            //return new RedirectResult("api/persons", permanent: false);
        }
    }
}