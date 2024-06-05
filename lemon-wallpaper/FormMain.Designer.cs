namespace lemon_wallpaper
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel_main = new System.Windows.Forms.Panel();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.MenuItem_config = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Wallpaper = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_see = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_pre = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_next = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_use_info = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_about = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_right_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_icon_pre = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_icon_next = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_view = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_main.SuspendLayout();
            this.contextMenuStrip_notify.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            resources.ApplyResources(this.panel_main, "panel_main");
            this.panel_main.Name = "panel_main";
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(208)))));
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_config,
            this.MenuItem_Wallpaper,
            this.MenuItem_help});
            resources.ApplyResources(this.menuStrip_main, "menuStrip_main");
            this.menuStrip_main.Name = "menuStrip_main";
            // 
            // MenuItem_config
            // 
            this.MenuItem_config.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MenuItem_config.Name = "MenuItem_config";
            resources.ApplyResources(this.MenuItem_config, "MenuItem_config");
            this.MenuItem_config.Click += new System.EventHandler(this.MenuItem_config_Click);
            // 
            // MenuItem_Wallpaper
            // 
            this.MenuItem_Wallpaper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_see,
            this.ToolStripMenuItem_pre,
            this.ToolStripMenuItem_next});
            this.MenuItem_Wallpaper.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MenuItem_Wallpaper.Name = "MenuItem_Wallpaper";
            resources.ApplyResources(this.MenuItem_Wallpaper, "MenuItem_Wallpaper");
            // 
            // ToolStripMenuItem_see
            // 
            this.ToolStripMenuItem_see.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripMenuItem_see.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.ToolStripMenuItem_see, "ToolStripMenuItem_see");
            this.ToolStripMenuItem_see.Name = "ToolStripMenuItem_see";
            this.ToolStripMenuItem_see.Click += new System.EventHandler(this.ToolStripMenuItem_see_Click);
            // 
            // ToolStripMenuItem_pre
            // 
            this.ToolStripMenuItem_pre.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripMenuItem_pre.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ToolStripMenuItem_pre.Image = global::lemon_wallpaper.Properties.Resources.arrowleft;
            this.ToolStripMenuItem_pre.Name = "ToolStripMenuItem_pre";
            resources.ApplyResources(this.ToolStripMenuItem_pre, "ToolStripMenuItem_pre");
            this.ToolStripMenuItem_pre.Click += new System.EventHandler(this.ToolStripMenuItem_pre_Click);
            // 
            // ToolStripMenuItem_next
            // 
            this.ToolStripMenuItem_next.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripMenuItem_next.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ToolStripMenuItem_next.Image = global::lemon_wallpaper.Properties.Resources.arrowright;
            this.ToolStripMenuItem_next.Name = "ToolStripMenuItem_next";
            resources.ApplyResources(this.ToolStripMenuItem_next, "ToolStripMenuItem_next");
            this.ToolStripMenuItem_next.Click += new System.EventHandler(this.ToolStripMenuItem_next_Click);
            // 
            // MenuItem_help
            // 
            this.MenuItem_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_use_info,
            this.toolStripMenuItem_about});
            this.MenuItem_help.ForeColor = System.Drawing.SystemColors.GrayText;
            this.MenuItem_help.Name = "MenuItem_help";
            resources.ApplyResources(this.MenuItem_help, "MenuItem_help");
            // 
            // toolStripMenuItem_use_info
            // 
            this.toolStripMenuItem_use_info.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripMenuItem_use_info.Image = global::lemon_wallpaper.Properties.Resources.question_circle;
            this.toolStripMenuItem_use_info.Name = "toolStripMenuItem_use_info";
            resources.ApplyResources(this.toolStripMenuItem_use_info, "toolStripMenuItem_use_info");
            this.toolStripMenuItem_use_info.Click += new System.EventHandler(this.toolStripMenuItem_use_info_Click);
            // 
            // toolStripMenuItem_about
            // 
            this.toolStripMenuItem_about.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripMenuItem_about.Image = global::lemon_wallpaper.Properties.Resources.info_circle;
            this.toolStripMenuItem_about.Name = "toolStripMenuItem_about";
            resources.ApplyResources(this.toolStripMenuItem_about, "toolStripMenuItem_about");
            this.toolStripMenuItem_about.Click += new System.EventHandler(this.toolStripMenuItem_about_Click);
            // 
            // notifyIcon_right_icon
            // 
            this.notifyIcon_right_icon.ContextMenuStrip = this.contextMenuStrip_notify;
            resources.ApplyResources(this.notifyIcon_right_icon, "notifyIcon_right_icon");
            this.notifyIcon_right_icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_right_icon_MouseClick);
            // 
            // contextMenuStrip_notify
            // 
            this.contextMenuStrip_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_icon_pre,
            this.toolStripMenuItem_icon_next,
            this.toolStripMenuItem_view,
            this.toolStripMenuItem_exit});
            this.contextMenuStrip_notify.Name = "contextMenuStrip_notify";
            resources.ApplyResources(this.contextMenuStrip_notify, "contextMenuStrip_notify");
            // 
            // toolStripMenuItem_icon_pre
            // 
            this.toolStripMenuItem_icon_pre.Name = "toolStripMenuItem_icon_pre";
            resources.ApplyResources(this.toolStripMenuItem_icon_pre, "toolStripMenuItem_icon_pre");
            this.toolStripMenuItem_icon_pre.Click += new System.EventHandler(this.toolStripMenuItem_icon_pre_Click);
            // 
            // toolStripMenuItem_icon_next
            // 
            this.toolStripMenuItem_icon_next.Name = "toolStripMenuItem_icon_next";
            resources.ApplyResources(this.toolStripMenuItem_icon_next, "toolStripMenuItem_icon_next");
            this.toolStripMenuItem_icon_next.Click += new System.EventHandler(this.toolStripMenuItem_icon_next_Click);
            // 
            // toolStripMenuItem_view
            // 
            this.toolStripMenuItem_view.Name = "toolStripMenuItem_view";
            resources.ApplyResources(this.toolStripMenuItem_view, "toolStripMenuItem_view");
            this.toolStripMenuItem_view.Click += new System.EventHandler(this.toolStripMenuItem_view_Click);
            // 
            // toolStripMenuItem_exit
            // 
            this.toolStripMenuItem_exit.Name = "toolStripMenuItem_exit";
            resources.ApplyResources(this.toolStripMenuItem_exit, "toolStripMenuItem_exit");
            this.toolStripMenuItem_exit.Click += new System.EventHandler(this.toolStripMenuItem_exit_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip_main);
            this.Controls.Add(this.panel_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip_main;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.contextMenuStrip_notify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_config;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Wallpaper;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_help;
        private System.Windows.Forms.NotifyIcon notifyIcon_right_icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_notify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_view;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_see;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_pre;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_next;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_icon_pre;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_icon_next;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_use_info;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_about;
    }
}

