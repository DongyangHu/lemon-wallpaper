using lemon_wallpaper.config;
using lemon_wallpaper.tools;
using System;
using System.IO;
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
    internal class ImgHistoryService : AbstractImgHistoryService
    {
        private static string[] imgHistoryArray;
        private int imgIndexCurrent;

        public ImgHistoryService()
        {
            this.DoInit();
        }

        protected override int DoCurrentImgIndex()
        {
            return this.imgIndexCurrent;
        }

        protected override void DoInit()
        {
            int historyCount = SettingsTools.GetIntSetting(Constants.IMG_HISTORY_COUNT_CONFIG_NAME);
            this.imgIndexCurrent = SettingsTools.GetIntSetting(Constants.IMG_HISTORY_CURRENT_INDEX_CONFIG_NAME);
            imgHistoryArray = new string[historyCount];
            // read the saved history
            string history = SettingsTools.GetStringSetting(Constants.IMG_HISTORY_CONFIG_NAME);
            if (string.IsNullOrEmpty(history))
            {
                return;
            }

            bool hasNotExistsImg = false;
            int diff = 0;
            string[] historyArray = history.Split(',');
            for (int i = 0; i < historyArray.Length; i++)
            {
                if (!this.ImgExists(historyArray[i]))
                {
                    hasNotExistsImg = true;
                    diff++;
                    continue;
                }
                imgHistoryArray[i - diff] = historyArray[i];
                if (i == this.imgIndexCurrent)
                {
                    this.imgIndexCurrent -= diff;
                }
            }
            if (hasNotExistsImg)
            {
                this.UpdateSettings(this.imgIndexCurrent, true);
            }
        }

        protected override int DoNextImgIndex()
        {
            if (imgIndexCurrent < 0)
            {
                return -1;
            }
            int nextIndex = imgIndexCurrent + 1;
            if (nextIndex >= imgHistoryArray.Length)
            {
                return -1;
            }
            if (imgHistoryArray[nextIndex] == null)
            {
                return -1;
            }
            return nextIndex;
        }

        protected override int DoPreviousImgIndex()
        {
            if (imgIndexCurrent < 0)
            {
                return -1;
            }
            int preIndex = imgIndexCurrent - 1;
            if (preIndex < 0)
            {
                return -1;
            }
            if (imgHistoryArray[preIndex] == null)
            {
                return -1;
            }
            return preIndex;
        }

        protected override int DoSetWallpaper(string imgPath)
        {
            if (!this.ImgExists(imgPath))
            {
                return 0;
            }

            // Must change config firstly
            this.AddElement(imgPath);
            return WallpaperTools.SetWallPaper(imgPath);
        }

        protected override int DoSetWallpaper(int imgIndex)
        {
            string imgPath = imgHistoryArray[imgIndex];
            if (!this.ImgExists(imgPath))
            {
                return 0;
            }
            this.imgIndexCurrent = imgIndex;
            this.UpdateSettings(imgIndex, false);
            return WallpaperTools.SetWallPaper(imgPath);
        }

        private bool ImgExists(string imgPath)
        {
            if (string.IsNullOrEmpty(imgPath))
            {
                return false;
            }
            string path = Path.GetDirectoryName(imgPath);
            if (!Directory.Exists(@path))
            {
                return false;
            }
            if (!File.Exists(@imgPath))
            {
                return false;
            }
            return true;
        }

        private void AddElement(string element)
        {
            bool addSuccess = false;
            for (int i = 0; i < imgHistoryArray.Length; i++)
            {
                if (string.IsNullOrEmpty(imgHistoryArray[i]))
                {
                    imgHistoryArray[i] = element;
                    this.imgIndexCurrent = i;
                    this.UpdateSettings(i, true);
                    addSuccess = true;
                    break;
                }
            }
            // Clean last element and add new one
            if (!addSuccess)
            {
                for (int i = 0; i < imgHistoryArray.Length - 1; i++)
                {
                    imgHistoryArray[i] = imgHistoryArray[i + 1];
                }
                imgHistoryArray[imgHistoryArray.Length - 1] = element;
                this.imgIndexCurrent = imgHistoryArray.Length - 1;
                this.UpdateSettings(imgHistoryArray.Length - 1, true);
            }
        }

        private void UpdateSettings(int currentIndex, bool isNew)
        {
            // don't modift the order
            if (isNew)
            {
                string historyStr = string.Empty;
                foreach (string item in imgHistoryArray)
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        break;
                    }
                    historyStr = historyStr + item + ",";
                }
                SettingsTools.UpdateSetting(Constants.IMG_HISTORY_CONFIG_NAME, historyStr.TrimEnd(','));
            }
            SettingsTools.UpdateSetting(Constants.IMG_HISTORY_CURRENT_INDEX_CONFIG_NAME, currentIndex);
        }

        protected override void DoDeleteExpireImg()
        {
            ImgExpireTimeConfig.ExpireTime expireTime = ImgExpireTimeConfig.ForIndex(SettingsTools.GetIntSetting(Constants.IMG_EXPIRE_TIME_CONFIG_NAME));
            if (expireTime == null || expireTime.Days <= 0)
            {
                return;
            }

            DateTime lastTime = TimeTools.TimeBeforeDays(expireTime.Days);
            string path = SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME);
            if (!Directory.Exists(@path))
            {
                return;
            }

            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                string fileTime = Path.GetFileNameWithoutExtension(filePath);
                if (fileTime.Length != 8)
                {
                    continue;
                }
                string year = fileTime.Substring(0, 4);
                string month = fileTime.Substring(4, 2);
                string day = fileTime.Substring(6, 2);
                DateTime dateTimeFile = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                if (dateTimeFile < lastTime && File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            this.DoInit();
        }
    }
}
