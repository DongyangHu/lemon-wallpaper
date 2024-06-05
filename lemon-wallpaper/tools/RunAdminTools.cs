using System;
using System.Diagnostics;
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
    internal class RunAdminTools
    {
        public static bool IsRuningByAdmin()
        {
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var windowsPrincipal = new System.Security.Principal.WindowsPrincipal(windowsIdentity);
            return windowsPrincipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        public static void RestartAsAdmin()
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = Application.ExecutablePath;
            processStartInfo.Verb = "runas";
            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Application.Exit();
        }
    }
}
