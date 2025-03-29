using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AdonisUI.Controls;

namespace CouitaTools
{
    public partial class Downloader : AdonisWindow
    {
        public Downloader()
        {
            InitializeComponent();
        }

        private async void Download_Click(object sender, RoutedEventArgs e)
        {
            string url = Text.Text.Trim();
            if (string.IsNullOrEmpty(url))
                return;

            try
            {
                await DownloadFileAsync(url);
            }
            catch (Exception ex) { }
        }

        private async Task DownloadFileAsync(string url)
        {
            string tempPath = Path.Combine(
                Path.GetTempPath(),
                $"{Guid.NewGuid().ToString("N").Substring(0, 32)}.exe"
            );

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                await client.DownloadFileTaskAsync(new Uri(url), tempPath);
                client.DownloadProgressChanged -= Client_DownloadProgressChanged;
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = tempPath,
                Verb = "runas",
                UseShellExecute = true
            };

            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception ex) { }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ProgressBar.Value = e.ProgressPercentage;
            });
        }
    }
}