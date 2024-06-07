using lemon_wallpaper.tools;
using NLog;
using System;
using System.Windows.Forms;

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

namespace lemon_wallpaper
{
    internal static class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Log.Info("Lemon Wallpaper Run...");
                bool repeat = ProcessHelper.CheckRepeat();
                if (repeat)
                {
                    Log.Info("CheckRepeat, exists process so skip run.");
                    ProcessHelper.Release();
                    return;
                }
                ProcessHelper.RunAdmin();
                Run(args);
            }
            catch (Exception e)
            {
                Log.Error("Main exception. message:{}\n StackTrace:{}", e.Message, e.StackTrace);
            }
        }

        static void Run(string[] args)
        {
            ProcessHelper.SetExecSelfStarting();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(args.Length > 0));
        }
    }
}
