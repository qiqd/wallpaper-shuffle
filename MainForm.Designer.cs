namespace WallpaperShuffle
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Setting = new System.Windows.Forms.TabPage();
            this.QuestionPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WallpaperSourceComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RestoreDefalutSettingBtn = new System.Windows.Forms.Button();
            this.ShowLogFileBtn = new System.Windows.Forms.Button();
            this.ChangeWallpaperSourceBtn = new System.Windows.Forms.Button();
            this.ChangeWallpaperDirBtn = new System.Windows.Forms.Button();
            this.EnableAutoCleanupCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoBootCheckBox = new System.Windows.Forms.CheckBox();
            this.About = new System.Windows.Forms.TabPage();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.QuestionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.WallPaperShuffleNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.WallpaperShuffleContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMainFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.auitplabel = new System.Windows.Forms.Label();
            this.AutoPlayIntervals = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CleanupInterval = new System.Windows.Forms.NumericUpDown();
            this.TabControl.SuspendLayout();
            this.Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPictureBox)).BeginInit();
            this.About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.WallpaperShuffleContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPlayIntervals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CleanupInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Setting);
            this.TabControl.Controls.Add(this.About);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(420, 265);
            this.TabControl.TabIndex = 1;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.CleanupInterval);
            this.Setting.Controls.Add(this.AutoPlayIntervals);
            this.Setting.Controls.Add(this.QuestionPictureBox);
            this.Setting.Controls.Add(this.textBox1);
            this.Setting.Controls.Add(this.WallpaperSourceComboBox);
            this.Setting.Controls.Add(this.label2);
            this.Setting.Controls.Add(this.label5);
            this.Setting.Controls.Add(this.label4);
            this.Setting.Controls.Add(this.auitplabel);
            this.Setting.Controls.Add(this.label3);
            this.Setting.Controls.Add(this.label1);
            this.Setting.Controls.Add(this.RestoreDefalutSettingBtn);
            this.Setting.Controls.Add(this.ShowLogFileBtn);
            this.Setting.Controls.Add(this.ChangeWallpaperSourceBtn);
            this.Setting.Controls.Add(this.ChangeWallpaperDirBtn);
            this.Setting.Controls.Add(this.EnableAutoCleanupCheckBox);
            this.Setting.Controls.Add(this.AutoBootCheckBox);
            this.Setting.Location = new System.Drawing.Point(4, 25);
            this.Setting.Name = "Setting";
            this.Setting.Padding = new System.Windows.Forms.Padding(3);
            this.Setting.Size = new System.Drawing.Size(412, 236);
            this.Setting.TabIndex = 3;
            this.Setting.Text = "设置";
            this.Setting.UseVisualStyleBackColor = true;
            // 
            // QuestionPictureBox
            // 
            this.QuestionPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.QuestionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("QuestionPictureBox.Image")));
            this.QuestionPictureBox.Location = new System.Drawing.Point(383, 105);
            this.QuestionPictureBox.Name = "QuestionPictureBox";
            this.QuestionPictureBox.Size = new System.Drawing.Size(19, 23);
            this.QuestionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QuestionPictureBox.TabIndex = 5;
            this.QuestionPictureBox.TabStop = false;
            this.QuestionToolTip.SetToolTip(this.QuestionPictureBox, "不知道如何使用？点击我");
            this.QuestionPictureBox.Click += new System.EventHandler(this.UsageGuideClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 76);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(278, 25);
            this.textBox1.TabIndex = 4;
            // 
            // WallpaperSourceComboBox
            // 
            this.WallpaperSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WallpaperSourceComboBox.FormattingEnabled = true;
            this.WallpaperSourceComboBox.Location = new System.Drawing.Point(82, 9);
            this.WallpaperSourceComboBox.Name = "WallpaperSourceComboBox";
            this.WallpaperSourceComboBox.Size = new System.Drawing.Size(320, 23);
            this.WallpaperSourceComboBox.TabIndex = 3;
            this.WallpaperSourceComboBox.SelectedIndexChanged += new System.EventHandler(this.WallpaperSourceChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "壁纸文件夹路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "壁纸来源";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RestoreDefalutSettingBtn
            // 
            this.RestoreDefalutSettingBtn.Location = new System.Drawing.Point(214, 184);
            this.RestoreDefalutSettingBtn.Name = "RestoreDefalutSettingBtn";
            this.RestoreDefalutSettingBtn.Size = new System.Drawing.Size(190, 46);
            this.RestoreDefalutSettingBtn.TabIndex = 1;
            this.RestoreDefalutSettingBtn.Text = "恢复默认";
            this.RestoreDefalutSettingBtn.UseVisualStyleBackColor = true;
            this.RestoreDefalutSettingBtn.Click += new System.EventHandler(this.RestoreDefaultSetting);
            // 
            // ShowLogFileBtn
            // 
            this.ShowLogFileBtn.Location = new System.Drawing.Point(214, 132);
            this.ShowLogFileBtn.Name = "ShowLogFileBtn";
            this.ShowLogFileBtn.Size = new System.Drawing.Size(190, 46);
            this.ShowLogFileBtn.TabIndex = 1;
            this.ShowLogFileBtn.Text = "查看日志文件";
            this.ShowLogFileBtn.UseVisualStyleBackColor = true;
            this.ShowLogFileBtn.Click += new System.EventHandler(this.ShowLogFile);
            // 
            // ChangeWallpaperSourceBtn
            // 
            this.ChangeWallpaperSourceBtn.Location = new System.Drawing.Point(9, 132);
            this.ChangeWallpaperSourceBtn.Name = "ChangeWallpaperSourceBtn";
            this.ChangeWallpaperSourceBtn.Size = new System.Drawing.Size(190, 46);
            this.ChangeWallpaperSourceBtn.TabIndex = 1;
            this.ChangeWallpaperSourceBtn.Text = "修改壁纸源文件";
            this.ChangeWallpaperSourceBtn.UseVisualStyleBackColor = true;
            this.ChangeWallpaperSourceBtn.Click += new System.EventHandler(this.ChangeWallpaperSorcesFIle);
            // 
            // ChangeWallpaperDirBtn
            // 
            this.ChangeWallpaperDirBtn.Location = new System.Drawing.Point(9, 184);
            this.ChangeWallpaperDirBtn.Name = "ChangeWallpaperDirBtn";
            this.ChangeWallpaperDirBtn.Size = new System.Drawing.Size(190, 46);
            this.ChangeWallpaperDirBtn.TabIndex = 1;
            this.ChangeWallpaperDirBtn.Text = "修改壁纸保存文件夹";
            this.ChangeWallpaperDirBtn.UseVisualStyleBackColor = true;
            this.ChangeWallpaperDirBtn.Click += new System.EventHandler(this.ChangeWallpaperSaveDir);
            // 
            // EnableAutoCleanupCheckBox
            // 
            this.EnableAutoCleanupCheckBox.AutoSize = true;
            this.EnableAutoCleanupCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.EnableAutoCleanupCheckBox.Checked = Properties.Settings.Default.AutoCleanup;
            this.EnableAutoCleanupCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnableAutoCleanupCheckBox.Location = new System.Drawing.Point(214, 107);
            this.EnableAutoCleanupCheckBox.Name = "EnableAutoCleanupCheckBox";
            this.EnableAutoCleanupCheckBox.Size = new System.Drawing.Size(134, 19);
            this.EnableAutoCleanupCheckBox.TabIndex = 0;
            this.EnableAutoCleanupCheckBox.Text = "自动清理旧壁纸";
            this.EnableAutoCleanupCheckBox.UseVisualStyleBackColor = true;
            this.EnableAutoCleanupCheckBox.CheckedChanged += new System.EventHandler(this.EnableAutoCleanup);
            // 
            // AutoBootCheckBox
            // 
            this.AutoBootCheckBox.AutoSize = true;
            this.AutoBootCheckBox.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.AutoBootCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoBootCheckBox.Location = new System.Drawing.Point(9, 107);
            this.AutoBootCheckBox.Name = "AutoBootCheckBox";
            this.AutoBootCheckBox.Size = new System.Drawing.Size(104, 19);
            this.AutoBootCheckBox.TabIndex = 0;
            this.AutoBootCheckBox.Text = "开机自启动";
            this.AutoBootCheckBox.UseVisualStyleBackColor = true;
            this.AutoBootCheckBox.Checked= Properties.Settings.Default.AutoBoot;
            
            this.AutoBootCheckBox.CheckedChanged += new System.EventHandler(this.EnableAutoBoot);
            // 
            // About
            // 
            this.About.Controls.Add(this.PictureBox);
            this.About.Controls.Add(this.AboutLabel);
            this.About.Location = new System.Drawing.Point(4, 25);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(412, 236);
            this.About.TabIndex = 4;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(200, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(212, 236);
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            // 
            // AboutLabel
            // 
            this.AboutLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AboutLabel.Location = new System.Drawing.Point(0, 0);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(200, 236);
            this.AboutLabel.TabIndex = 0;
            this.AboutLabel.Text = "label3";
            // 
            // QuestionToolTip
            // 
            this.QuestionToolTip.ToolTipTitle = "Tip";
            // 
            // WallPaperShuffleNotify
            // 
            this.WallPaperShuffleNotify.ContextMenuStrip = this.WallpaperShuffleContextMenuStrip;
            this.WallPaperShuffleNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("WallPaperShuffleNotify.Icon")));
            this.WallPaperShuffleNotify.Text = "每日随机壁纸";
            this.WallPaperShuffleNotify.Visible = true;
            // 
            // WallpaperShuffleContextMenuStrip
            // 
            this.WallpaperShuffleContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.WallpaperShuffleContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMainFormItem,
            this.ExitItem});
            this.WallpaperShuffleContextMenuStrip.Name = "WallpaperShuffleContextMenuStrip";
            this.WallpaperShuffleContextMenuStrip.Size = new System.Drawing.Size(139, 52);
            // 
            // ShowMainFormItem
            // 
            this.ShowMainFormItem.Name = "ShowMainFormItem";
            this.ShowMainFormItem.Size = new System.Drawing.Size(138, 24);
            this.ShowMainFormItem.Text = "主页面";
            this.ShowMainFormItem.Click += new System.EventHandler(this.ShowMainFormStrip);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(138, 24);
            this.ExitItem.Text = "退出程序";
            this.ExitItem.Click += new System.EventHandler(this.QuitAppStrip);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "壁纸来源";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // auitplabel
            // 
            this.auitplabel.AutoSize = true;
            this.auitplabel.Location = new System.Drawing.Point(6, 48);
            this.auitplabel.Name = "auitplabel";
            this.auitplabel.Size = new System.Drawing.Size(67, 15);
            this.auitplabel.TabIndex = 2;
            this.auitplabel.Text = "播放间隔";
            this.auitplabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuestionToolTip.SetToolTip(this.auitplabel, "单位：分钟");
            // 
            // AutoPlayIntervals
            // 
            this.AutoPlayIntervals.Location = new System.Drawing.Point(82, 45);
            this.AutoPlayIntervals.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AutoPlayIntervals.Name = "AutoPlayIntervals";
            this.AutoPlayIntervals.Size = new System.Drawing.Size(97, 25);
            this.AutoPlayIntervals.TabIndex = 6;
            this.QuestionToolTip.SetToolTip(this.AutoPlayIntervals, "单位：分钟");
            this.AutoPlayIntervals.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.AutoPlayIntervals.ValueChanged += new System.EventHandler(this.OnIntervalCalueChange);
            // 
            // label4
            // 
            this.label4.CausesValidation = false;
            this.label4.Location = new System.Drawing.Point(208, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "壁纸来源";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.CausesValidation = false;
            this.label5.Location = new System.Drawing.Point(211, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "清理间隔";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuestionToolTip.SetToolTip(this.label5, "单位：分钟");
            // 
            // CleanupInterval
            // 
            this.CleanupInterval.CausesValidation = false;
            this.CleanupInterval.Location = new System.Drawing.Point(287, 44);
            this.CleanupInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.CleanupInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CleanupInterval.Name = "CleanupInterval";
            this.CleanupInterval.Size = new System.Drawing.Size(97, 25);
            this.CleanupInterval.TabIndex = 6;
            this.QuestionToolTip.SetToolTip(this.CleanupInterval, "单位：分钟");
            this.CleanupInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.CleanupInterval.ValueChanged += new System.EventHandler(this.OnCleanupIntervalChange);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 265);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "每日随机壁纸";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.TabControl.ResumeLayout(false);
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestionPictureBox)).EndInit();
            this.About.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.WallpaperShuffleContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AutoPlayIntervals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CleanupInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Setting;
        private System.Windows.Forms.CheckBox AutoBootCheckBox;
        private System.Windows.Forms.TabPage About;
        private System.Windows.Forms.Button ChangeWallpaperDirBtn;
        private System.Windows.Forms.Button ChangeWallpaperSourceBtn;
        private System.Windows.Forms.Button ShowLogFileBtn;
        private System.Windows.Forms.Button RestoreDefalutSettingBtn;
        private System.Windows.Forms.ComboBox WallpaperSourceComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.PictureBox QuestionPictureBox;
        private System.Windows.Forms.ToolTip QuestionToolTip;
        private System.Windows.Forms.NotifyIcon WallPaperShuffleNotify;
        private System.Windows.Forms.ContextMenuStrip WallpaperShuffleContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowMainFormItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.CheckBox EnableAutoCleanupCheckBox;
        private System.Windows.Forms.NumericUpDown AutoPlayIntervals;
        private System.Windows.Forms.Label auitplabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CleanupInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

