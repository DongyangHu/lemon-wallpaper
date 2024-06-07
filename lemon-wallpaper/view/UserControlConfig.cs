using lemon_wallpaper.config;
using lemon_wallpaper.service.impl;
using lemon_wallpaper.tools;
using NLog;
using System;
using System.Drawing;
using System.IO;
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
namespace lemon_wallpaper.view
{
    public partial class UserControlConfig : UserControl, ICustomInit
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private readonly WallpaperService wallpaperService;
        private readonly ImgHistoryService imgHistoryService;

        public UserControlConfig()
        {
            this.wallpaperService = new WallpaperService();
            this.imgHistoryService = new ImgHistoryService();
            this.wallpaperService.InitData();
            InitializeComponent();
            this.AsyncJob();
        }

        public void CustomFocus()
        {

        }

        public void CustomInit()
        {
            this.comboBox_source.Items.AddRange(ImgSourceConfig.Items());
            this.comboBox_source.SelectedIndex = SettingsTools.GetIntSetting(Constants.IMG_SOURCE_CONFIG_NAME);
            this.comboBox_expire.Items.AddRange(ImgExpireTimeConfig.Items());
            this.comboBox_expire.SelectedIndex = SettingsTools.GetIntSetting(Constants.IMG_EXPIRE_TIME_CONFIG_NAME);
        }

        /// <summary>
        /// 壁纸来源变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_source_SelectedValueChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            Log.Info("Change wallpaper source, index:{}", selectedIndex);
            SettingsTools.UpdateSetting(Constants.IMG_SOURCE_CONFIG_NAME, selectedIndex);
        }

        /// <summary>
        /// Save path changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_save_path_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "请选择壁纸文件保存目录"
            };
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar + SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_PREFIX_CONFIG_NAME);
                Log.Info("Change wallpaper save path, path:{}", path);
                SettingsTools.UpdateSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME, path);
            }
        }

        private void AsyncJob()
        {
            Log.Info("Async job init.");
            Thread thread = ThreadTools.buildThread("wallpaper-manager", () =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(SettingsTools.GetIntSetting(Constants.JOB_RUN_UNIT_CONFIG_NAME));
                        Log.Info("[AsyncJob] running...");
                        this.imgHistoryService.DeleteExpireImg();
                        Log.Info("[AsyncJob] DeleteExpireImg end.");

                        if (!RunEnable())
                        {
                            Log.Info("[AsyncJob] Wallpaper was chaned today, skip running.");
                            continue;
                        }
                        //init data
                        this.wallpaperService.InitData();

                        // 下载壁纸
                        ImgSourceConfig.Source source = ImgSourceConfig.ForIndex(SettingsTools.GetIntSetting(Constants.IMG_SOURCE_CONFIG_NAME));
                        string imgUrl = this.wallpaperService.DownloadImg(source);
                        if (imgUrl == null)
                        {
                            Log.Error("[AsyncJob] download wallpaper is failed.");
                            continue;
                        }

                        // 修改壁纸,更新修改时间
                        Log.Info("[AsyncJob] update wallpaper, path:{}", imgUrl);
                        int setResult = this.imgHistoryService.SetWallpaper(imgUrl);
                        if (setResult == 0)
                        {
                            Log.Error("[AsyncJob] update wallpaper failed, setResult is zero");
                            continue;
                        }
                        else
                        {
                            SettingsTools.UpdateSetting(Constants.LABEL_UPDATE_TIME_CONFIG_NAME, TimeTools.TimeGeneral());
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            });
            thread.Start();
        }

        private bool RunEnable()
        {
            string updateTimeStr = SettingsTools.GetStringSetting(Constants.LABEL_UPDATE_TIME_CONFIG_NAME);
            if (string.IsNullOrEmpty(updateTimeStr))
            {
                return true;
            }
            DateTime updateTime = TimeTools.TimeDate(updateTimeStr);
            return updateTime.CompareTo(TimeTools.TimeGeneral0()) < 0;
        }

        /// <summary>
        /// 刷新页面属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_refresh_Tick(object sender, EventArgs e)
        {
            this.label_update_time_info.Text = SettingsTools.GetStringSetting(Constants.LABEL_UPDATE_TIME_CONFIG_NAME);
        }

        /// <summary>
        /// Expire time changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_expire_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingsTools.UpdateSetting(Constants.IMG_EXPIRE_TIME_CONFIG_NAME, ((ComboBox)sender).SelectedIndex);
        }

        private void label_update_time_info_MouseHover(object sender, EventArgs e)
        {
            this.label_update_time_info.ForeColor = SystemColors.ControlDarkDark;
        }

        private void label_update_time_info_MouseLeave(object sender, EventArgs e)
        {
            this.label_update_time_info.ForeColor = SystemColors.ControlText;
        }
    }
}
