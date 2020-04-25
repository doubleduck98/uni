using System.ComponentModel;

namespace zadanie2._1._6
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.workerBar = new System.Windows.Forms.ProgressBar();
            this.threadBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.workerLabel = new System.Windows.Forms.Label();
            this.threadLabel = new System.Windows.Forms.Label();
            this.workerTimeLabel = new System.Windows.Forms.Label();
            this.threadTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork +=
                new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged +=
                new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted +=
                new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // workerBar
            // 
            this.workerBar.Location = new System.Drawing.Point(12, 53);
            this.workerBar.Name = "workerBar";
            this.workerBar.Size = new System.Drawing.Size(414, 32);
            this.workerBar.TabIndex = 0;
            // 
            // threadBar
            // 
            this.threadBar.Location = new System.Drawing.Point(430, 53);
            this.threadBar.Name = "threadBar";
            this.threadBar.Size = new System.Drawing.Size(414, 32);
            this.threadBar.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(341, 91);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(171, 36);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // workerLabel
            // 
            this.workerLabel.Location = new System.Drawing.Point(147, 9);
            this.workerLabel.Name = "workerLabel";
            this.workerLabel.Size = new System.Drawing.Size(148, 42);
            this.workerLabel.TabIndex = 3;
            this.workerLabel.Text = "Background Worker";
            this.workerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // threadLabel
            // 
            this.threadLabel.Location = new System.Drawing.Point(580, 9);
            this.threadLabel.Name = "threadLabel";
            this.threadLabel.Size = new System.Drawing.Size(148, 42);
            this.threadLabel.TabIndex = 4;
            this.threadLabel.Text = "Thread";
            this.threadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // workerTimeLabel
            // 
            this.workerTimeLabel.Location = new System.Drawing.Point(147, 92);
            this.workerTimeLabel.Name = "workerTimeLabel";
            this.workerTimeLabel.Size = new System.Drawing.Size(126, 35);
            this.workerTimeLabel.TabIndex = 5;
            this.workerTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // threadTimeLabel
            // 
            this.threadTimeLabel.Location = new System.Drawing.Point(602, 92);
            this.threadTimeLabel.Name = "threadTimeLabel";
            this.threadTimeLabel.Size = new System.Drawing.Size(126, 35);
            this.threadTimeLabel.TabIndex = 6;
            this.threadTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 138);
            this.Controls.Add(this.threadTimeLabel);
            this.Controls.Add(this.workerTimeLabel);
            this.Controls.Add(this.threadLabel);
            this.Controls.Add(this.workerLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.threadBar);
            this.Controls.Add(this.workerBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label workerLabel;
        private System.Windows.Forms.Label threadLabel;
        private System.Windows.Forms.ProgressBar threadBar;
        private System.Windows.Forms.ProgressBar workerBar;
        private System.Windows.Forms.Label workerTimeLabel;
        private System.Windows.Forms.Label threadTimeLabel;
    }
}