namespace lemon_wallpaper.view
{
    partial class UserControlConfig
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_source = new System.Windows.Forms.ComboBox();
            this.label_update_time = new System.Windows.Forms.Label();
            this.label_expire = new System.Windows.Forms.Label();
            this.label_save_path = new System.Windows.Forms.Label();
            this.label_source = new System.Windows.Forms.Label();
            this.comboBox_expire = new System.Windows.Forms.ComboBox();
            this.label_update_time_info = new System.Windows.Forms.Label();
            this.textBox_save_path = new System.Windows.Forms.TextBox();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comboBox_source
            // 
            this.comboBox_source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(208)))));
            this.comboBox_source.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_source.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_source.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_source.FormattingEnabled = true;
            this.comboBox_source.Location = new System.Drawing.Point(129, 13);
            this.comboBox_source.Name = "comboBox_source";
            this.comboBox_source.Size = new System.Drawing.Size(121, 20);
            this.comboBox_source.TabIndex = 12;
            this.comboBox_source.SelectedValueChanged += new System.EventHandler(this.comboBox_source_SelectedValueChanged);
            // 
            // label_update_time
            // 
            this.label_update_time.AutoSize = true;
            this.label_update_time.Font = new System.Drawing.Font("宋体", 9F);
            this.label_update_time.ForeColor = System.Drawing.Color.White;
            this.label_update_time.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_update_time.Location = new System.Drawing.Point(36, 115);
            this.label_update_time.Name = "label_update_time";
            this.label_update_time.Size = new System.Drawing.Size(89, 12);
            this.label_update_time.TabIndex = 11;
            this.label_update_time.Text = "壁纸更新时间：";
            // 
            // label_expire
            // 
            this.label_expire.AutoSize = true;
            this.label_expire.Font = new System.Drawing.Font("宋体", 9F);
            this.label_expire.ForeColor = System.Drawing.Color.White;
            this.label_expire.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_expire.Location = new System.Drawing.Point(36, 82);
            this.label_expire.Name = "label_expire";
            this.label_expire.Size = new System.Drawing.Size(89, 12);
            this.label_expire.TabIndex = 9;
            this.label_expire.Text = "壁纸保存时间：";
            // 
            // label_save_path
            // 
            this.label_save_path.AutoSize = true;
            this.label_save_path.Font = new System.Drawing.Font("宋体", 9F);
            this.label_save_path.ForeColor = System.Drawing.Color.White;
            this.label_save_path.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_save_path.Location = new System.Drawing.Point(36, 49);
            this.label_save_path.Name = "label_save_path";
            this.label_save_path.Size = new System.Drawing.Size(89, 12);
            this.label_save_path.TabIndex = 8;
            this.label_save_path.Text = "壁纸保存目录：";
            this.label_save_path.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Font = new System.Drawing.Font("宋体", 9F);
            this.label_source.ForeColor = System.Drawing.Color.White;
            this.label_source.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_source.Location = new System.Drawing.Point(60, 16);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(65, 12);
            this.label_source.TabIndex = 7;
            this.label_source.Text = "壁纸来源：";
            this.label_source.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_expire
            // 
            this.comboBox_expire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(208)))));
            this.comboBox_expire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox_expire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_expire.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_expire.FormattingEnabled = true;
            this.comboBox_expire.Location = new System.Drawing.Point(129, 79);
            this.comboBox_expire.Name = "comboBox_expire";
            this.comboBox_expire.Size = new System.Drawing.Size(121, 20);
            this.comboBox_expire.TabIndex = 14;
            this.comboBox_expire.SelectedIndexChanged += new System.EventHandler(this.comboBox_expire_SelectedIndexChanged);
            // 
            // label_update_time_info
            // 
            this.label_update_time_info.AutoSize = true;
            this.label_update_time_info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_update_time_info.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::lemon_wallpaper.Properties.Settings.Default, "label_update_time", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.label_update_time_info.Location = new System.Drawing.Point(130, 116);
            this.label_update_time_info.Name = "label_update_time_info";
            this.label_update_time_info.Size = new System.Drawing.Size(0, 12);
            this.label_update_time_info.TabIndex = 16;
            this.label_update_time_info.Text = global::lemon_wallpaper.Properties.Settings.Default.label_update_time;
            this.label_update_time_info.MouseLeave += new System.EventHandler(this.label_update_time_info_MouseLeave);
            this.label_update_time_info.MouseHover += new System.EventHandler(this.label_update_time_info_MouseHover);
            // 
            // textBox_save_path
            // 
            this.textBox_save_path.BackColor = System.Drawing.Color.White;
            this.textBox_save_path.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_save_path.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::lemon_wallpaper.Properties.Settings.Default, "img_save_path", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox_save_path.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_save_path.Location = new System.Drawing.Point(129, 44);
            this.textBox_save_path.Name = "textBox_save_path";
            this.textBox_save_path.ReadOnly = true;
            this.textBox_save_path.Size = new System.Drawing.Size(189, 21);
            this.textBox_save_path.TabIndex = 13;
            this.textBox_save_path.Text = global::lemon_wallpaper.Properties.Settings.Default.img_save_path;
            this.textBox_save_path.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox_save_path_MouseDoubleClick);
            // 
            // timer_refresh
            // 
            this.timer_refresh.Enabled = true;
            this.timer_refresh.Interval = 5000;
            this.timer_refresh.Tick += new System.EventHandler(this.timer_refresh_Tick);
            // 
            // UserControlConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(236)))), ((int)(((byte)(191)))));
            this.Controls.Add(this.label_update_time_info);
            this.Controls.Add(this.comboBox_expire);
            this.Controls.Add(this.textBox_save_path);
            this.Controls.Add(this.comboBox_source);
            this.Controls.Add(this.label_update_time);
            this.Controls.Add(this.label_expire);
            this.Controls.Add(this.label_save_path);
            this.Controls.Add(this.label_source);
            this.Name = "UserControlConfig";
            this.Size = new System.Drawing.Size(360, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_source;
        private System.Windows.Forms.Label label_update_time;
        private System.Windows.Forms.Label label_expire;
        private System.Windows.Forms.Label label_save_path;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.TextBox textBox_save_path;
        private System.Windows.Forms.ComboBox comboBox_expire;
        private System.Windows.Forms.Label label_update_time_info;
        private System.Windows.Forms.Timer timer_refresh;
    }
}
