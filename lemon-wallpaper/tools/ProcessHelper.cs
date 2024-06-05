using Microsoft.Win32;
using lemon_wallpaper.config;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
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
        private static Mutex mutex;

        private static bool IsRepeat()
        {
            Process currentProcess = Process.GetCurrentProcess();
            string processName = currentProcess.ProcessName;
            mutex = new Mutex(true, processName, out bool createNew);
            return !createNew;
        }

        private static void Release()
        {
            mutex?.ReleaseMutex();
        }

        public static void ExitProcess()
        {
            Release();
            Application.Exit();
            Environment.Exit(0);
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

        public static void CheckRepeat()
        {
            if (IsRepeat())
            {
                ShowProcess();
                ExitProcess();
            }
        }

        public static void SetExecSelfStarting()
        {
            try
            {
                var execPath = Application.ExecutablePath;
                using (RegistryKey registryRoot = Registry.CurrentUser)
                {
                    string[] resigetry = new string[] { "Software\\Microsoft\\Windows\\CurrentVersion\\Run", "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run" };
                    foreach (var resigetryPath in resigetry)
                    {
                        Console.WriteLine("注册表路径:" + resigetryPath);
                        using (RegistryKey subRegistry = registryRoot.CreateSubKey(resigetryPath))
                        {
                            Console.WriteLine("二级路径:" + subRegistry.ToString());
                            if (subRegistry == null)
                            {
                                return;
                            }
                            string name = SettingsTools.GetStringSetting(Constants.REGEDIT_KEY_CONFIG_NAME);
                            var value = subRegistry.GetValue(name) ?? string.Empty;
                            Console.WriteLine("注册表值:" + value);

                            if (execPath.Equals(value.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                return;
                            }
                            subRegistry.SetValue(name, execPath + " --autostart");
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
            bool needAdmin = executablePath.StartsWith(@"C:\Program Files (x86)", StringComparison.OrdinalIgnoreCase) ||
                executablePath.StartsWith(@"C:\Program Files", StringComparison.OrdinalIgnoreCase);
            if (!needAdmin)
            {
                return;
            }
            if (!RunAdminTools.IsRuningByAdmin())
            {
                RunAdminTools.RestartAsAdmin();
            }
        }
    }
}
