using System;
using System.Windows.Forms;

namespace zadanie2._1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newNode = new TreeNode("Nowy wierzchołek");
            treeView1.SelectedNode.Nodes.Add(newNode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove(treeView1.SelectedNode);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var next = progressBar1.Value;
            if (next + 2 > progressBar1.Maximum)
            {
                next = progressBar1.Maximum;
            }
            else
            {
                next += 2;
            }

            progressBar1.Value = next;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var next = progressBar1.Value;
            if (next - 2 < progressBar1.Minimum)
            {
                next = progressBar1.Minimum;
            }
            else
            {
                next -= 2;
            }

            progressBar1.Value = next;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}