namespace zadanie2._1._2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("11");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("12");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("13");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("1",
                new System.Windows.Forms.TreeNode[] {treeNode1, treeNode2, treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("21");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("22");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("23");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("2",
                new System.Windows.Forms.TreeNode[] {treeNode5, treeNode6, treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("31");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("32");
            System.Windows.Forms.TreeNode treeNode11 =
                new System.Windows.Forms.TreeNode("3", new System.Windows.Forms.TreeNode[] {treeNode9, treeNode10});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(159, 40);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Węzeł3";
            treeNode1.Text = "11";
            treeNode2.Name = "Węzeł4";
            treeNode2.Text = "12";
            treeNode3.Name = "Węzeł5";
            treeNode3.Text = "13";
            treeNode4.Name = "Węzeł0";
            treeNode4.Text = "1";
            treeNode5.Name = "Węzeł6";
            treeNode5.Text = "21";
            treeNode6.Name = "Węzeł7";
            treeNode6.Text = "22";
            treeNode7.Name = "Węzeł8";
            treeNode7.Text = "23";
            treeNode8.Name = "Węzeł1";
            treeNode8.Text = "2";
            treeNode9.Name = "Węzeł9";
            treeNode9.Text = "31";
            treeNode10.Name = "Węzeł10";
            treeNode10.Text = "32";
            treeNode11.Name = "Węzeł2";
            treeNode11.Text = "3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {treeNode4, treeNode8, treeNode11});
            this.treeView1.Size = new System.Drawing.Size(207, 155);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj węzeł";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(372, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Usuń węzeł";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 232);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(726, 68);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 32;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(302, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 63);
            this.button3.TabIndex = 4;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(372, 306);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 63);
            this.button4.TabIndex = 5;
            this.button4.Text = "-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(261, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tree  View";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(261, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Progress Bar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(261, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "List Box";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {"coś", "coś więcej"});
            this.listBox1.Location = new System.Drawing.Point(159, 406);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(207, 154);
            this.listBox1.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(372, 445);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 30);
            this.button5.TabIndex = 10;
            this.button5.Text = "Dodaj element";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(372, 481);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 30);
            this.button6.TabIndex = 11;
            this.button6.Text = "Usuń element";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 573);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
    }
}