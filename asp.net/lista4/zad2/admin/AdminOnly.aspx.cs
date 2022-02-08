using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zad2.admin
{
    public partial class AdminOnly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = User.Identity.Name;
            Label2.Text = User.IsInRole("admin") ? "admin" : "nieadmin";
        }
    }
}