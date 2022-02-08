using System;
using System.Configuration;

namespace zad2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            // minimalna weryfikacja
            if (string.IsNullOrEmpty(username.Text)
                || string.IsNullOrEmpty(email.Text)
                || string.IsNullOrEmpty(password.Text))
            {
                message.Text = "uzupełnij pola";
                return;
            }
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new UsersDataContext(cs))
            {
                var newUser = new USER()
                {
                    nazwa = username.Text,
                    email = email.Text
                };
                var newPassword = new PASSWORD()
                {
                    USER = newUser,
                    password1 = BCrypt.Net.BCrypt.EnhancedHashPassword(password.Text)
                };
                ctx.USER.InsertOnSubmit(newUser);
                ctx.PASSWORD.InsertOnSubmit(newPassword);
                ctx.SubmitChanges();
                ctx.Dispose();
            }
            Response.Redirect("Login.aspx");
        }
    }
}