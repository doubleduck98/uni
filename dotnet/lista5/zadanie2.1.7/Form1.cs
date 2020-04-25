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
            var resp1 = await Client.GetStringAsync("https://pl.wikipedia.org/wiki/Robert_Kubica");
            var resp2 = await Client.GetStringAsync("https://pl.wikipedia.org/wiki/Lewis_Hamilton");
            var resp3 = await Client.GetStringAsync("https://pl.wikipedia.org/wiki/Max_Verstappen");
            var title1 = Regex.Match(resp1, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            var title2 = Regex.Match(resp2, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            var title3 = Regex.Match(resp3, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            asyncListBox.Items.Add(title1);
            asyncListBox.Items.Add(title2);
            asyncListBox.Items.Add(title3);
        }
        
        private void asyncStartButton_Click(object sender, EventArgs e)
        {
            asyncListBox.Items.Clear();
            DownloadAsync();
            for (var i = 1; i < 10; ++i)
            {
                asyncListBox.Items.Add(i);
            }
        }

        private void DownloadSync()
        {
            var wc = new WebClient();

            var resp1 = wc.DownloadString("https://pl.wikipedia.org/wiki/Robert_Kubica");
            var resp2 = wc.DownloadString("https://pl.wikipedia.org/wiki/Lewis_Hamilton");
            var resp3 = wc.DownloadString("https://pl.wikipedia.org/wiki/Max_Verstappen");
            var title1 = Regex.Match(resp1, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            var title2 = Regex.Match(resp2, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            var title3 = Regex.Match(resp3, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
            listBox.Items.Add(title1);
            listBox.Items.Add(title2);
            listBox.Items.Add(title3);
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            DownloadSync();
            for (var i = 1; i < 10; ++i)
            {
                listBox.Items.Add(i);
            }
        }
    }
}