using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie2._1._7
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient Client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async Task DownloadAsync()
        {
            for (var i = 0; i < 30; i++)
            {
                var resp = await Client.GetStringAsync("https://pl.wikipedia.org/wiki/Robert_Kubica");
                var title = Regex.Match(resp, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                    RegexOptions.IgnoreCase).Groups["Title"].Value;
                asyncListBox.Items.Add(title);

            }
        }
        
        private async void asyncStartButton_Click(object sender, EventArgs e)
        {
            asyncListBox.Items.Clear();
            await DownloadAsync();
        }

        private void DownloadSync()
        {
            var wc = new WebClient();
            for (var i = 0; i < 30; i++)
            {
                var resp = wc.DownloadString("https://pl.wikipedia.org/wiki/Robert_Kubica");
                var title = Regex.Match(resp, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                    RegexOptions.IgnoreCase).Groups["Title"].Value;
                listBox.Items.Add(title);
            }
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            DownloadSync();
        }
    }
}