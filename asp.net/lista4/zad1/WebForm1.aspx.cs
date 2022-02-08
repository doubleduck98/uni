using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace zad1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Label2.Text = User.Identity.IsAuthenticated ? User.Identity.Name : "anon";
            Label3.Text = User.GetType().Name;
        }
    }
}