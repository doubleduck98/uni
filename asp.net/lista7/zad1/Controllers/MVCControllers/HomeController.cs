using System.Web.Mvc;

namespace zad1.Controllers.MVCControllers
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