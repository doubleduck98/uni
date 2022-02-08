using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using zad2.Models;

namespace zad2.Controllers.MVCControllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
            //return new RedirectResult("api/persons", permanent: false);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Membership.ValidateUser(model.Email, model.Password))
                {
                    ModelState.AddModelError("login", "Błędne dane!");
                    return View(model);
                }

                var username = Membership.GetUserNameByEmail(model.Email);
                var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, username);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.AppendCookie(cookie);

                var returnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = FormsAuthentication.DefaultUrl;
                }
                return Redirect(returnUrl);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("Index");
        }
    }
}