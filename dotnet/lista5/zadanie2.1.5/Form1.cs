using System;
using System.Windows.Forms;

namespace zadanie2._1._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonHelperClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void TextBoxHelperClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider2.HelpNamespace);
        }
    }
}