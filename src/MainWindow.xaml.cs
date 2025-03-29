using System.Windows;
using AdonisUI.Controls;

namespace CouitaTools
{
    public partial class MainWindow : AdonisWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tools_Click(object sender, RoutedEventArgs e)
        {
            var toolsWindow = new Tools();
            toolsWindow.Show();
        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            var unlockWindow = new Unlock();
            unlockWindow.Show();
        }

        private void Downloader_Click(object sender, RoutedEventArgs e)
        {
            var downloaderWindow = new Downloader();
            downloaderWindow.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new About();
            aboutWindow.Show();
        }
    }
}