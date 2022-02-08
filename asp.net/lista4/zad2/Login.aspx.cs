using System;
using System.Web.Security;
using System.Web;

namespace zad2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                message.Text = "odmowa dostępu - wymagane uprawnienia administratora";
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(password.Text))
            {
                message.Text = "uzupełnij pola";
                return;
            }

            if (!Membership.ValidateUser(email.Text, password.Text))
            {
                message.Text = "błędne dane";
                return;
            }

            var username = Membership.GetUserNameByEmail(email.Text);
            var ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, username);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.AppendCookie(cookie);

            var returnUrl = Request.QueryString["ReturnUrl"];
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = FormsAuthentication.DefaultUrl;
            }
            Response.Redirect(returnUrl);
        }

        protected void RegBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}