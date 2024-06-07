using Microsoft.Win32;
using lemon_wallpaper.config;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using NLog;
///
/// Copyright 2024 DongyangHu, hudongyang123@gmail.com
///
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///   http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
namespace lemon_wallpaper.tools
{
    public static class ProcessHelper
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private static Mutex mutex;

        private static bool IsRepeat()
        {
            Process currentProcess = Process.GetCurrentProcess();
            string processName = currentProcess.ProcessName;
            mutex = new Mutex(true, processName, out bool createNew);
            return !createNew;
        }

        public static void Release()
        {
            mutex?.ReleaseMutex();
        }

        public static void ExitProcess()
        {
            Log.Info("Exit process");
            Release();
            Application.Exit();
        }


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_RESTORE = 9;

        /// <summary>
        /// 展示已运行窗体
        /// </summary>
        private static void ShowProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (process.Id != currentProcess.Id)
                {
                    if (IsIconic(process.MainWindowHandle))
                    {
                        ShowWindow(process.MainWindowHandle, SW_RESTORE);
                    }
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }

        public static bool CheckRepeat()
        {
            return IsRepeat();
        }

        public static void SetExecSelfStarting()
        {
            Log.Info("SetExecSelfStarting enter.");
            try
            {
                var newRegistryValue = Application.ExecutablePath + " --autostart";
                using (RegistryKey registryRoot = Registry.CurrentUser)
                {
                    string[] registry = new string[] { "Software\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run" };
                    foreach (var registryPath in registry)
                    {
                        using (RegistryKey subRegistry = registryRoot.CreateSubKey(registryPath))
                        {
                            if (subRegistry == null)
                            {
                                Log.Error("SetExecSelfStarting subRegistry is null, resigetryPath:{}, subRegistry:{}", registryPath, subRegistry.ToString());
                                return;
                            }
                            string name = SettingsTools.GetStringSetting(Constants.REGEDIT_KEY_CONFIG_NAME);
                            var value = subRegistry.GetValue(name) ?? string.Empty;
                            Log.Info("SetExecSelfStarting modify registry, registryPath:{}, subRegistry:{}, curValue:{}", registryPath, subRegistry.ToString(), value);
                            if (newRegistryValue.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                Log.Info("SetExecSelfStarting skip modify registry");
                                return;
                            }
                            subRegistry.SetValue(name, newRegistryValue);
                            Log.Info("SetExecSelfStarting modify registry, oldValue:{}, newValue:{}", value, newRegistryValue);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void RunAdmin()
        {
            string executablePath = Application.ExecutablePath;
            bool runAppPath = executablePath.StartsWith(@"C:\Program Files (x86)", StringComparison.OrdinalIgnoreCase) ||
                executablePath.StartsWith(@"C:\Program Files", StringComparison.OrdinalIgnoreCase);
            bool runWithWin7C = RunWithWin7() && executablePath.StartsWith(@"C:\", StringComparison.OrdinalIgnoreCase);
            Log.Info("RunAdmin logic,executablePath:{}, runAppPath:{}, win7C:{}.", executablePath, runWithWin7C);
            if (!runAppPath && !runWithWin7C)
            {
                return;
            }
            if (!RunAdminTools.IsRuningByAdmin())
            {
                RunAdminTools.RestartAsAdmin();
            }
        }

        public static bool RunWithWin7()
        {
            OperatingSystem os = Environment.OSVersion;
            Version version = os.Version;
            return version.Major == 6 && version.Minor == 1;
        }
    }
}
