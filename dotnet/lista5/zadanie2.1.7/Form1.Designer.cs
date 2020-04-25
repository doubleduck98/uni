namespace zadanie2._1._7
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
            this.asyncStartButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.asyncListBox = new System.Windows.Forms.ListBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // asyncStartButton
            // 
            this.asyncStartButton.Location = new System.Drawing.Point(12, 277);
            this.asyncStartButton.Name = "asyncStartButton";
            this.asyncStartButton.Size = new System.Drawing.Size(178, 36);
            this.asyncStartButton.TabIndex = 2;
            this.asyncStartButton.Text = "Async";
            this.asyncStartButton.UseVisualStyleBackColor = true;
            this.asyncStartButton.Click += new System.EventHandler(this.asyncStartButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(196, 277);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(178, 36);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Sync";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // asyncListBox
            // 
            this.asyncListBox.FormattingEnabled = true;
            this.asyncListBox.ItemHeight = 15;
            this.asyncListBox.Location = new System.Drawing.Point(12, 12);
            this.asyncListBox.Name = "asyncListBox";
            this.asyncListBox.Size = new System.Drawing.Size(178, 259);
            this.asyncListBox.TabIndex = 4;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(196, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(178, 259);
            this.listBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 320);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.asyncListBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.asyncStartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button asyncStartButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ListBox asyncListBox;
    }
}