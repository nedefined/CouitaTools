using System;
using System.Collections.Generic;
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
            catch (Exception) { }
        }

        private async Task DownloadFileAsync(string url)
        {
            if (CheckBox.IsChecked == true)
            {
                string randomName = $"{Guid.NewGuid().ToString("N").Substring(0, 32)}.exe";
                string tempPath = Path.Combine(Path.GetTempPath(), randomName);

                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += Client_DownloadProgressChanged;
                    await client.DownloadFileTaskAsync(new Uri(url), tempPath);
                    client.DownloadProgressChanged -= Client_DownloadProgressChanged;
                }

                var folderNames = new List<string>();
                Random rand = new Random();
                int folderCount = 4 + rand.Next(9);

                for (int i = 0; i < folderCount; i++)
                {
                    string folderName = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString("N").Substring(0, 32)}");
                    Directory.CreateDirectory(folderName);
                    File.SetAttributes(folderName, FileAttributes.Hidden);
                    folderNames.Add(folderName);
                }

                foreach (string folder in folderNames)
                {
                    File.Copy(tempPath, Path.Combine(folder, randomName), true);
                }

                var processStartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(folderNames[rand.Next(folderNames.Count)], randomName),
                    Verb = "runas",
                    UseShellExecute = true
                };

                try
                {
                    Process.Start(processStartInfo);
                }
                catch (Exception) { }
            }
            else
            {
                string tempPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid().ToString("N").Substring(0, 32)}.exe");

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
                catch (Exception) { }
            }
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