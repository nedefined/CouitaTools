using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using AdonisUI.Controls;

namespace CouitaTools
{
    public partial class Tools : AdonisWindow
    {
        public Tools()
        {
            InitializeComponent();
        }

        private void PH2_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tools\GLGYXH\TXkCPVWYcYdHKdKy.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex) { }
        }

        private void PE_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tools\prex.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex) { }
        }

        private void PM_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\\prmn.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception) { }
        }

        private void TCPView_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\\tcpv.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception) { }
        }

        private void AutoRun_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\\aur.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception) { }
        }

        private void EPP_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\\exp.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception) { }
        }

        private void TR_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools\\TR.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception) { }
        }

        private void AVZ_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tools\LBZXNH\dbrriebght.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex) { }
        }

        private void AutoLogger_Click(object sender, RoutedEventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"tools\aulo.exe");
            try
            {
                Process.Start(exePath);
            }
            catch (Exception ex) { }
        }
    }
}