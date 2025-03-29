using System.Diagnostics;
using System.Windows;
using AdonisUI.Controls;

namespace CouitaTools
{
    public partial class About : AdonisWindow
    {
        public About()
        {
            InitializeComponent(); 
        }

        public void TG_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://t.me/CouitaChannel1",
                UseShellExecute = true
            });
        }

        public void GH_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://github.com/CouitaCommunity/CouitaTools",
                UseShellExecute = true
            });
        }
    }
}