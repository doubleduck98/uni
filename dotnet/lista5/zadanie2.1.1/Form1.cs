using System;
using System.Text;
using System.Windows.Forms;

namespace zadanie2._1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AkceptujClick(object sender, EventArgs e)
        {
            var message = new StringBuilder();
            var caption = "Uczelnia";
            message.Append($"{textBox1.Text}\n");
            message.Append($"{textBox2.Text}\n");
            message.Append($"{comboBox1.Text}\n");
            if (checkBox1.Checked)
            {
                message.Append($"{checkBox1.Text} ");
            } else if (checkBox2.Checked)
            {
                message.Append($"{checkBox2.Text}");
            }

            MessageBox.Show(message.ToString(), caption, MessageBoxButtons.OK);
        }

        private void AnulujClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}