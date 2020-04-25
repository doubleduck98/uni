using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace zadanie2._1._6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            workerTimeLabel.Text = "";
            workerBar.Value = 0;
            threadTimeLabel.Text = "";
            threadBar.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            RunThread();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var start = DateTime.Now;

            for (var i = 100000; i <= 200000; ++i)
            {
                for (var j = 2; j < i; ++j)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                }

                if (i % 1000 == 0)
                {
                    worker?.ReportProgress(i - 100000);
                }
            }

            e.Result = DateTime.Now - start;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            workerBar.Value = e.ProgressPercentage / 1000;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                workerTimeLabel.Text = e.Result.ToString();
            }
        }

        private void RunThread()
        {
            var t = new Thread(ThreadProc);
            t.Start();
            // gdzieś tutaj powinienem wołać join (?)
        }

        private void ThreadProc()
        {
            var start = DateTime.Now;
            
            for (var i = 100000; i <= 200000; ++i)
            {
                for (var j = 2; j < i; ++j)
                {
                    if (i % j == 0)
                    {
                        break;
                    }
                }

                if (i % 1000 == 0)
                {
                    threadBar.Value = (i - 100000) / 1000;
                }
            }

            threadTimeLabel.Text = (DateTime.Now - start).ToString();
        }
    }
}