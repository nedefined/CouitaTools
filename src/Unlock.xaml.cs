using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AdonisUI.Controls;

namespace CouitaTools
{
    public partial class Unlock : AdonisWindow
    {
        public Unlock()
        {
            InitializeComponent();
        }

        private void Unlock_Click(object sender, RoutedEventArgs e)
        {
            var registryChanges = new List<(string Key, string ValueName, object Value)>
            {
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\SystemRestore", "DisableSR", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\SystemRestore", "DisableRestore", 0),
                ("HKCU:\\Software\\Policies\\Microsoft\\Windows", "DisableCMD", 0),
                ("HKCU:\\Software\\Policies\\Microsoft\\MMC", "RestrictToPermittedSnapins", 0),
                ("HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableTaskMgr", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoFolderOptions", 0),
                ("HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ActiveDesktop", "NoChangingWallPaper", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoWinKeys", 0),
                ("HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableChangePassword", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableLockWorkstation", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "HidePowerOptions", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "DisableContextMenusInStart", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "StartMenuLogOff", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoClose", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "StartMenuPowerButton", 0),
                ("HKLM:\\SYSTEM\\CurrentControlSet\\Control\\Lsa", "DisableChangePassword", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "HideFastUserSwitching", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoControlPanel", 0),
                ("HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", "HideIcons", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoCommonGroups", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoFind", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoLogoff", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", "NoSetTaskbar", 0),
                ("HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", "DisableRegistryTools", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableAntiSpyware", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableBehaviorMonitoring", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableOnAccessProtection", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableScanOnRealtimeEnable", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableIOAVProtection", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "DisableRealtimeMonitoring", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideDisableOnAccessProtection", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideRealtimeScanDirection", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideDisableIOAVProtection", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideDisableBehaviorMonitoring", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideDisableIntrusionPreventionSystem", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender\\Real-Time Protection", "LocalSettingOverrideDisableRealtimeMonitoring", 0),
                ("HKLM:\\SOFTWARE\\Microsoft\\Windows Defender", "PUAProtection", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\System", "EnableSmartScreen", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\MRT", "DontOfferThroughWUA", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\MRT", "DontReportInfectionInformation", 0),
                ("HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\SystemRestore", "DisableConfig", 0)
            };

            double progressStep = 100.0 / registryChanges.Count;
            ProgressBar1.Value = 0;

            Task.Run(() =>
            {
                foreach (var entry in registryChanges)
                {
                    try
                    {
                        if (entry.Key != null)
                        {
                            DeleteRegistryValue(entry.Key, entry.ValueName);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        Dispatcher.Invoke(() =>
                            ProgressBar1.Value += progressStep);
                    }
                }
                Dispatcher.Invoke(() => ProgressBar1.Value = 100);
            });
        }

        private void DeleteRegistryValue(string key, string valueName)
        {
            string script = $@"Remove-ItemProperty -Path '{key}' -Name '{valueName}' -ErrorAction SilentlyContinue";

            try
            {
                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-Command \"{script}\"",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Verb = "runas"
                    };

                    process.Start();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}