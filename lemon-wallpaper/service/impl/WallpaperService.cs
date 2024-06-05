using lemon_wallpaper.config;
using lemon_wallpaper.tools;
using System;
using System.IO;
using System.Threading.Tasks;
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
namespace lemon_wallpaper.service.impl
{
    internal class WallpaperService : IWallpaperService
    {

        public string DownloadImg(ImgSourceConfig.Source source)
        {
            Task<string> task = this.BuildImgUrl(source);
            string downUrl = task.Result;
            if (downUrl == null)
            {
                return null;
            }
            Console.WriteLine(downUrl);
            Task<bool> result = ImgDownloadTools.DownloadFile(downUrl, SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME), this.BuildFileName());
            if (!result.Result)
            {
                return null;
            }
            return SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME) + Path.DirectorySeparatorChar + this.BuildFileName();
        }

        private async Task<string> BuildImgUrl(ImgSourceConfig.Source source)
        {
            string url = await ImgDownloadTools.HttpRequest(source, (o, s) =>
            {
                if (s == ImgSourceConfig.BING)
                {
                    return s.BaseUrl + o["images"][0]["url"].ToString();
                }
                if (s == ImgSourceConfig.BING_MODEL)
                {
                    //return s.BaseUrl + o["MediaContents"][0]["ImageContent"]["Image"]["Wallpaper"];
                    return "" + o["MediaContents"][0]["ImageContent"]["Image"]["Url"];
                }
                if (s == ImgSourceConfig.WALLHAVEN)
                {
                    return "" + o["data"][0]["path"];
                }
                return null;
            });
            return url;
        }

        private string BuildFileName()
        {
            return TimeTools.TimeNumber() + ".jpg";
        }

        public void InitData()
        {
            bool firstRun = SettingsTools.GetBoolSetting(Constants.APP_FIRST_RUN_CONFIG_NAME);
            string savePath = SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME);
            if (!string.IsNullOrEmpty(savePath) && !firstRun)
            {
                return;
            }

            string executablePath = Application.ExecutablePath;
            string initSavePath = Path.GetDirectoryName(executablePath) + Path.DirectorySeparatorChar + SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_PREFIX_CONFIG_NAME);
            if (!Directory.Exists(@initSavePath))
            {
                Directory.CreateDirectory(@initSavePath);
            }
            SettingsTools.UpdateSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME, initSavePath);
            SettingsTools.UpdateSetting(Constants.APP_FIRST_RUN_CONFIG_NAME, false);
        }
    }
}
