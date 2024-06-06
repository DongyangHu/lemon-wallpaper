using Microsoft.Win32;
using NLog;
using System;
using System.Runtime.InteropServices;
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
namespace lemon_wallpaper
{
    internal class WallpaperTools
    {

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        const int SPI_SETDESKWALLPAPER = 0x0014;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        /// <summary>
        /// 设置用户系统参数
        /// </summary>
        /// <param name="uAction">用户操作</param>
        /// <param name="uParam">参数</param>
        /// <param name="lpvParam">参数</param>
        /// <param name="fuWinIni">更新winini</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", SetLastError = true)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessageTimeout(IntPtr hWnd, uint Msg, UIntPtr wParam, string lParam, uint fuFlags, uint uTimeout, out UIntPtr lpdwResult);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static int SetWallPaper(String path)
        {
            int result = SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, @path, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            if (result == 0)
            {
                int errorCode = Marshal.GetLastWin32Error();
                Log.Error("SetWallPaper SystemParametersInfo failed, result is zero. errorCode:{}", errorCode);
                return result;
            }

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
            {
                if (key != null)
                {
                    key.SetValue(@"WallpaperStyle", "2"); // 0 = 平铺, 1 = 居中, 2 = 填充
                    key.SetValue(@"TileWallpaper", "0"); // 0 = 不平铺, 1 = 水平平铺, 2 = 垂直平铺, 3 = 水平垂直平铺
                    key.SetValue(@"Wallpaper", @path);
                    Log.Info("SetWallPaper update registry success");
                }
                else
                {
                    Log.Error("SetWallPaper update registry failed");
                    return 0;
                }
            }
            RefreshDesktop();
            return result;
        }

        private static void RefreshDesktop()
        {
            IntPtr hwnd = FindWindow("Progman", "Program Manager");
            if (hwnd != IntPtr.Zero)
            {
                SendMessageTimeout(hwnd, 0x052c, (UIntPtr)0, null, 0, 1000, out _);
            }
        }
    }
}
