using lemon_wallpaper.config;
using lemon_wallpaper.service.impl;
using lemon_wallpaper.tools;
using lemon_wallpaper.view;
using System;
using System.Diagnostics;
using System.Reflection;
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
namespace lemon_wallpaper
{
    public partial class FormMain : Form
    {

        private UserControlConfig userControlConfig;
        private FormAbout formAbout;
        private FormUserGuide formUserGuide;
        private ImgHistoryService imgHistoryService;
        private bool isAutoRun;

        public FormMain(bool isAutoRun)
        {
            this.isAutoRun = isAutoRun;
            this.userControlConfig = new UserControlConfig();
            this.formAbout = new FormAbout();
            this.formUserGuide = new FormUserGuide();
            this.imgHistoryService = new ImgHistoryService();
            InitializeComponent();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            this.UserControlConfigShow();
            if (isAutoRun)
            {
                this.Hide();
                return;
            }
        }

        private void UserControlConfigShow()
        {
            this.ChangeView(this.userControlConfig);
        }

        private void ChangeView(UserControl userControl)
        {
            userControl.Show();
            this.panel_main.Controls.Clear();
            this.panel_main.Controls.Add(userControl);
            try
            {
                Type controlType = userControl.GetType();
                MethodInfo customInitMethod = controlType.GetMethod("CustomInit");
                customInitMethod?.Invoke(userControl, new object[] { });
                MethodInfo customFocusMethod = controlType.GetMethod("CustomFocus");
                customFocusMethod?.Invoke(userControl, new object[] { });
            }
            catch (Exception e)
            {
                MessageBox.Show(userControl.Name + "初始化失败，可能导致运行异常！" + e.Message);
            }
        }

        private void notifyIcon_right_icon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void toolStripMenuItem_exit_Click(object sender, EventArgs e)
        {
            ProcessHelper.ExitProcess();
        }

        private void MenuItem_config_Click(object sender, EventArgs e)
        {
            this.UserControlConfigShow();
        }

        private void ToolStripMenuItem_see_Click(object sender, EventArgs e)
        {
            this.SeeWallpaper();
        }

        private void ToolStripMenuItem_pre_Click(object sender, EventArgs e)
        {
            this.PreWallpaper();
        }

        private void ToolStripMenuItem_next_Click(object sender, EventArgs e)
        {
            this.NextWallpaper();
        }

        private void toolStripMenuItem_icon_pre_Click(object sender, EventArgs e)
        {
            this.PreWallpaper();
        }

        private void toolStripMenuItem_icon_next_Click(object sender, EventArgs e)
        {
            this.NextWallpaper();
        }

        private void toolStripMenuItem_view_Click(object sender, EventArgs e)
        {
            this.SeeWallpaper();
        }

        private void SeeWallpaper()
        {
            string folderPath = @SettingsTools.GetStringSetting(Constants.IMG_SAVE_PATH_CONFIG_NAME);
            Process.Start("explorer.exe", folderPath);
        }

        private void PreWallpaper()
        {
            this.ChangeWallpaper(this.imgHistoryService.PreviousImgIndex());
        }

        private void NextWallpaper()
        {
            this.ChangeWallpaper(this.imgHistoryService.NextImgIndex());
        }

        private void ChangeWallpaper(int imgIndex)
        {
            if (imgIndex < 0)
            {
                new FormPrompt(SettingsTools.GetStringSetting(Constants.IMG_CHANGE_PROMPT_CONFIG_NAME)).ShowDialog();
                return;
            }
            int result = this.imgHistoryService.SetWallpaper(imgIndex);
            if(result == 0)
            {
                new FormPrompt(SettingsTools.GetStringSetting(Constants.IMG_CHANGE_PROMPT_CONFIG_NAME)).ShowDialog();
                return;
            }
            SettingsTools.UpdateSetting(Constants.LABEL_UPDATE_TIME_CONFIG_NAME, TimeTools.TimeGeneral());
        }

        private void toolStripMenuItem_about_Click(object sender, EventArgs e)
        {
            this.formAbout.ShowDialog();
        }

        private void toolStripMenuItem_use_info_Click(object sender, EventArgs e)
        {
            this.formUserGuide.ShowDialog();
        }
    }
}
