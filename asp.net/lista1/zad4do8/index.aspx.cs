using System;
using System.IO;
using System.Web.UI;

namespace zad4do8
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sr = new StreamReader(@"C:\Temp\randomFile.txt");
                var txt = sr.ReadLine();
                RandomLabel.Text = txt;
            }
        }
    }
}