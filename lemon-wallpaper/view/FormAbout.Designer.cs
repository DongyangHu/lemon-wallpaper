namespace lemon_wallpaper.view
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBox_about = new System.Windows.Forms.PictureBox();
            this.label_version = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_version_cur = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.linkLabel_ = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_about
            // 
            this.pictureBox_about.Image = global::lemon_wallpaper.Properties.Resources.lemon_64;
            this.pictureBox_about.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_about.Name = "pictureBox_about";
            this.pictureBox_about.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_about.TabIndex = 0;
            this.pictureBox_about.TabStop = false;
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.ForeColor = System.Drawing.Color.Goldenrod;
            this.label_version.Location = new System.Drawing.Point(98, 23);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(65, 12);
            this.label_version.TabIndex = 27;
            this.label_version.Text = "软件版本：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "All rights reserved.";
            // 
            // label_version_cur
            // 
            this.label_version_cur.AutoSize = true;
            this.label_version_cur.Location = new System.Drawing.Point(158, 23);
            this.label_version_cur.Name = "label_version_cur";
            this.label_version_cur.Size = new System.Drawing.Size(41, 12);
            this.label_version_cur.TabIndex = 28;
            this.label_version_cur.Text = global::lemon_wallpaper.Properties.Settings.Default.app_version;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.richTextBox1.Location = new System.Drawing.Point(12, 91);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(316, 186);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "本软件基于Bing的API接口封装，自动更换Bing每日壁纸。\n\n【免责声明】\n1.本软件内部所载的任何资料、信息或内容等，均仅限于供个人或单位内部使用，请勿用于" +
    "商业用途或出版发行；\n2.仅限完全行为能力人使用本软件，使用本软件即视为使用者的自愿行为；\n3.本人不对任何人因使用本软件所遭受的任何理论或实际的损失承担责任；" +
    "\n4.本人不保证软件的普适性，不保证无BUG，不保证绝对的安全稳定。";
            // 
            // linkLabel_
            // 
            this.linkLabel_.AutoSize = true;
            this.linkLabel_.LinkArea = new System.Windows.Forms.LinkArea(0, 30);
            this.linkLabel_.Location = new System.Drawing.Point(98, 44);
            this.linkLabel_.Name = "linkLabel_";
            this.linkLabel_.Size = new System.Drawing.Size(185, 12);
            this.linkLabel_.TabIndex = 34;
            this.linkLabel_.TabStop = true;
            this.linkLabel_.Text = "Copyright (c) 2024 DongyangHu.";
            this.linkLabel_.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel__LinkClicked);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 285);
            this.Controls.Add(this.linkLabel_);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_version_cur);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.pictureBox_about);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于柠檬壁纸";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_about;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_version_cur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel linkLabel_;
    }
}