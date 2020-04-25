namespace zadanie2._1._5
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button1helper = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button2helper = new System.Windows.Forms.Button();
            this.helpProvider2 = new System.Windows.Forms.HelpProvider();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxhelper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Przycisk";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Textbox";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "btn1.chm";
            // 
            // button1helper
            // 
            this.button1helper.Location = new System.Drawing.Point(195, 12);
            this.button1helper.Name = "button1helper";
            this.button1helper.Size = new System.Drawing.Size(131, 43);
            this.button1helper.TabIndex = 2;
            this.button1helper.Text = "Pomoc";
            this.button1helper.UseVisualStyleBackColor = true;
            this.button1helper.Click += new System.EventHandler(this.ButtonHelperClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 43);
            this.button2.TabIndex = 3;
            this.button2.Text = "Przycisk";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button2helper
            // 
            this.button2helper.Location = new System.Drawing.Point(195, 61);
            this.button2helper.Name = "button2helper";
            this.button2helper.Size = new System.Drawing.Size(131, 43);
            this.button2helper.TabIndex = 4;
            this.button2helper.Text = "Pomoc";
            this.button2helper.UseVisualStyleBackColor = true;
            this.button2helper.Click += new System.EventHandler(this.ButtonHelperClick);
            // 
            // helpProvider2
            // 
            this.helpProvider2.HelpNamespace = "textbox1.chm";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Po naciśnięciu przycisku pomoc pokaże się Helper.";
            // 
            // textBoxhelper
            // 
            this.textBoxhelper.Location = new System.Drawing.Point(195, 110);
            this.textBoxhelper.Name = "textBoxhelper";
            this.textBoxhelper.Size = new System.Drawing.Size(130, 22);
            this.textBoxhelper.TabIndex = 7;
            this.textBoxhelper.Text = "Pomoc";
            this.textBoxhelper.UseVisualStyleBackColor = true;
            this.textBoxhelper.Click += new System.EventHandler(this.TextBoxHelperClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 178);
            this.Controls.Add(this.textBoxhelper);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2helper);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1helper);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "CHM";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.HelpProvider helpProvider2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button textBoxhelper;
        private System.Windows.Forms.Button button1helper;
        private System.Windows.Forms.Button button2helper;
    }
}