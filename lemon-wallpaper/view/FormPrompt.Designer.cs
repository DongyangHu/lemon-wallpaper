namespace lemon_wallpaper.view
{
    partial class FormPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrompt));
            this.label_msg = new System.Windows.Forms.Label();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_msg
            // 
            this.label_msg.Font = new System.Drawing.Font("宋体", 9F);
            this.label_msg.Location = new System.Drawing.Point(8, 21);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(160, 23);
            this.label_msg.TabIndex = 0;
            this.label_msg.Text = "label_msg";
            this.label_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(47, 65);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(75, 23);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "好的";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // FormPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 100);
            this.ControlBox = false;
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label_msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrompt";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.Button button_exit;
    }
}
