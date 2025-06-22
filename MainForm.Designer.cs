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
            this.UsageGuideBtn = new System.Windows.Forms.Button();
            this.CleanupInterval = new System.Windows.Forms.NumericUpDown();
            this.AutoPlayIntervals = new System.Windows.Forms.NumericUpDown();
            this.WallpaperSaveDirTextBox = new System.Windows.Forms.TextBox();
            this.WallpaperSourceComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.auitplabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowWallpaperSaveDirBtn = new System.Windows.Forms.Button();
            this.RestoreDefalutSettingBtn = new System.Windows.Forms.Button();
            this.ShowLogFileBtn = new System.Windows.Forms.Button();
            this.ChangeWallpaperSourceBtn = new System.Windows.Forms.Button();
            this.ChangeWallpaperDirBtn = new System.Windows.Forms.Button();
            this.EnableAutoCleanupCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoBootCheckBox = new System.Windows.Forms.CheckBox();
            this.About = new System.Windows.Forms.TabPage();
            this.AboutRightPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AboutLeftPanel = new System.Windows.Forms.Panel();
            this.GitHubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GiteeLlinkLable = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.QuestionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.WallPaperShuffleNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.WallpaperShuffleContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMainFormItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CleanupInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPlayIntervals)).BeginInit();
            this.About.SuspendLayout();
            this.AboutRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.AboutLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.WallpaperShuffleContextMenuStrip.SuspendLayout();
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
            this.TabControl.Size = new System.Drawing.Size(445, 265);
            this.TabControl.TabIndex = 1;
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.UsageGuideBtn);
            this.Setting.Controls.Add(this.CleanupInterval);
            this.Setting.Controls.Add(this.AutoPlayIntervals);
            this.Setting.Controls.Add(this.WallpaperSaveDirTextBox);
            this.Setting.Controls.Add(this.WallpaperSourceComboBox);
            this.Setting.Controls.Add(this.label2);
            this.Setting.Controls.Add(this.label5);
            this.Setting.Controls.Add(this.label4);
            this.Setting.Controls.Add(this.auitplabel);
            this.Setting.Controls.Add(this.label3);
            this.Setting.Controls.Add(this.label1);
            this.Setting.Controls.Add(this.ShowWallpaperSaveDirBtn);
            this.Setting.Controls.Add(this.RestoreDefalutSettingBtn);
            this.Setting.Controls.Add(this.ShowLogFileBtn);
            this.Setting.Controls.Add(this.ChangeWallpaperSourceBtn);
            this.Setting.Controls.Add(this.ChangeWallpaperDirBtn);
            this.Setting.Controls.Add(this.EnableAutoCleanupCheckBox);
            this.Setting.Controls.Add(this.AutoBootCheckBox);
            this.Setting.Location = new System.Drawing.Point(4, 25);
            this.Setting.Name = "Setting";
            this.Setting.Padding = new System.Windows.Forms.Padding(3);
            this.Setting.Size = new System.Drawing.Size(437, 236);
            this.Setting.TabIndex = 3;
            this.Setting.Text = "设置";
            this.Setting.UseVisualStyleBackColor = true;
            // 
            // UsageGuideBtn
            // 
            this.UsageGuideBtn.Location = new System.Drawing.Point(139, 182);
            this.UsageGuideBtn.Name = "UsageGuideBtn";
            this.UsageGuideBtn.Size = new System.Drawing.Size(94, 46);
            this.UsageGuideBtn.TabIndex = 7;
            this.UsageGuideBtn.Text = "使用教程";
            this.UsageGuideBtn.UseVisualStyleBackColor = true;
            this.UsageGuideBtn.Click += new System.EventHandler(this.UsageGuideClick);
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
            // WallpaperSaveDirTextBox
            // 
            this.WallpaperSaveDirTextBox.Location = new System.Drawing.Point(126, 76);
            this.WallpaperSaveDirTextBox.Name = "WallpaperSaveDirTextBox";
            this.WallpaperSaveDirTextBox.ReadOnly = true;
            this.WallpaperSaveDirTextBox.Size = new System.Drawing.Size(278, 25);
            this.WallpaperSaveDirTextBox.TabIndex = 4;
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "壁纸来源";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // ShowWallpaperSaveDirBtn
            // 
            this.ShowWallpaperSaveDirBtn.Location = new System.Drawing.Point(8, 132);
            this.ShowWallpaperSaveDirBtn.Name = "ShowWallpaperSaveDirBtn";
            this.ShowWallpaperSaveDirBtn.Size = new System.Drawing.Size(224, 46);
            this.ShowWallpaperSaveDirBtn.TabIndex = 1;
            this.ShowWallpaperSaveDirBtn.Text = "查看壁纸保存文件夹";
            this.ShowWallpaperSaveDirBtn.UseVisualStyleBackColor = true;
            this.ShowWallpaperSaveDirBtn.Click += new System.EventHandler(this.ShowWallpaperSaveDir);
            // 
            // RestoreDefalutSettingBtn
            // 
            this.RestoreDefalutSettingBtn.Location = new System.Drawing.Point(339, 182);
            this.RestoreDefalutSettingBtn.Name = "RestoreDefalutSettingBtn";
            this.RestoreDefalutSettingBtn.Size = new System.Drawing.Size(90, 46);
            this.RestoreDefalutSettingBtn.TabIndex = 1;
            this.RestoreDefalutSettingBtn.Text = "恢复默认";
            this.RestoreDefalutSettingBtn.UseVisualStyleBackColor = true;
            this.RestoreDefalutSettingBtn.Click += new System.EventHandler(this.RestoreDefaultSetting);
            // 
            // ShowLogFileBtn
            // 
            this.ShowLogFileBtn.Location = new System.Drawing.Point(239, 182);
            this.ShowLogFileBtn.Name = "ShowLogFileBtn";
            this.ShowLogFileBtn.Size = new System.Drawing.Size(94, 46);
            this.ShowLogFileBtn.TabIndex = 1;
            this.ShowLogFileBtn.Text = "查看日志";
            this.ShowLogFileBtn.UseVisualStyleBackColor = true;
            this.ShowLogFileBtn.Click += new System.EventHandler(this.ShowLogFile);
            // 
            // ChangeWallpaperSourceBtn
            // 
            this.ChangeWallpaperSourceBtn.Location = new System.Drawing.Point(9, 182);
            this.ChangeWallpaperSourceBtn.Name = "ChangeWallpaperSourceBtn";
            this.ChangeWallpaperSourceBtn.Size = new System.Drawing.Size(124, 46);
            this.ChangeWallpaperSourceBtn.TabIndex = 1;
            this.ChangeWallpaperSourceBtn.Text = "修改壁纸源文件";
            this.ChangeWallpaperSourceBtn.UseVisualStyleBackColor = true;
            this.ChangeWallpaperSourceBtn.Click += new System.EventHandler(this.ChangeWallpaperSorcesFIle);
            // 
            // ChangeWallpaperDirBtn
            // 
            this.ChangeWallpaperDirBtn.Location = new System.Drawing.Point(239, 132);
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
            this.EnableAutoCleanupCheckBox.Checked = global::WallpaperShuffle.Properties.Settings.Default.AutoCleanup;
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
            this.AutoBootCheckBox.Checked = global::WallpaperShuffle.Properties.Settings.Default.AutoBoot;
            this.AutoBootCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoBootCheckBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AutoBootCheckBox.Location = new System.Drawing.Point(9, 107);
            this.AutoBootCheckBox.Name = "AutoBootCheckBox";
            this.AutoBootCheckBox.Size = new System.Drawing.Size(104, 19);
            this.AutoBootCheckBox.TabIndex = 0;
            this.AutoBootCheckBox.Text = "开机自启动";
            this.AutoBootCheckBox.UseVisualStyleBackColor = true;
            this.AutoBootCheckBox.CheckedChanged += new System.EventHandler(this.EnableAutoBoot);
            // 
            // About
            // 
            this.About.Controls.Add(this.AboutRightPanel);
            this.About.Controls.Add(this.AboutLeftPanel);
            this.About.Controls.Add(this.PictureBox);
            this.About.Location = new System.Drawing.Point(4, 25);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(437, 236);
            this.About.TabIndex = 4;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            // 
            // AboutRightPanel
            // 
            this.AboutRightPanel.Controls.Add(this.pictureBox2);
            this.AboutRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutRightPanel.Location = new System.Drawing.Point(216, 0);
            this.AboutRightPanel.Name = "AboutRightPanel";
            this.AboutRightPanel.Size = new System.Drawing.Size(221, 236);
            this.AboutRightPanel.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(221, 236);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // AboutLeftPanel
            // 
            this.AboutLeftPanel.Controls.Add(this.GitHubLinkLabel);
            this.AboutLeftPanel.Controls.Add(this.GiteeLlinkLable);
            this.AboutLeftPanel.Controls.Add(this.label9);
            this.AboutLeftPanel.Controls.Add(this.label8);
            this.AboutLeftPanel.Controls.Add(this.pictureBox1);
            this.AboutLeftPanel.Controls.Add(this.label6);
            this.AboutLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.AboutLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.AboutLeftPanel.Name = "AboutLeftPanel";
            this.AboutLeftPanel.Size = new System.Drawing.Size(216, 236);
            this.AboutLeftPanel.TabIndex = 2;
            // 
            // GitHubLinkLabel
            // 
            this.GitHubLinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.GitHubLinkLabel.AutoSize = true;
            this.GitHubLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.GitHubLinkLabel.Location = new System.Drawing.Point(115, 186);
            this.GitHubLinkLabel.Name = "GitHubLinkLabel";
            this.GitHubLinkLabel.Size = new System.Drawing.Size(55, 15);
            this.GitHubLinkLabel.TabIndex = 4;
            this.GitHubLinkLabel.TabStop = true;
            this.GitHubLinkLabel.Text = "GitHub";
            this.GitHubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLinkClick);
            // 
            // GiteeLlinkLable
            // 
            this.GiteeLlinkLable.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(145)))), ((int)(((byte)(139)))));
            this.GiteeLlinkLable.AutoSize = true;
            this.GiteeLlinkLable.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(216)))), ((int)(((byte)(213)))));
            this.GiteeLlinkLable.Location = new System.Drawing.Point(31, 186);
            this.GiteeLlinkLable.Name = "GiteeLlinkLable";
            this.GiteeLlinkLable.Size = new System.Drawing.Size(47, 15);
            this.GiteeLlinkLable.TabIndex = 4;
            this.GiteeLlinkLable.TabStop = true;
            this.GiteeLlinkLable.Text = "Gitee";
            this.GiteeLlinkLable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GiteeLinkClick);
            // 
            // label9
            // 
            this.label9.AutoEllipsis = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("幼圆", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(3, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 63);
            this.label9.TabIndex = 3;
            this.label9.Text = "如果觉得好用的话\r\n✨ 给项目点个Star吧🌟";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(79, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "版本 1.0.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(78, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "每日随机壁纸";
            // 
            // PictureBox
            // 
            this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(437, 236);
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(445, 265);
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
            ((System.ComponentModel.ISupportInitialize)(this.CleanupInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoPlayIntervals)).EndInit();
            this.About.ResumeLayout(false);
            this.AboutRightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.AboutLeftPanel.ResumeLayout(false);
            this.AboutLeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.WallpaperShuffleContextMenuStrip.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox WallpaperSaveDirTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PictureBox;
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
        private System.Windows.Forms.Button ShowWallpaperSaveDirBtn;
        private System.Windows.Forms.Button UsageGuideBtn;
        private System.Windows.Forms.Panel AboutLeftPanel;
        private System.Windows.Forms.Panel AboutRightPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel GitHubLinkLabel;
        private System.Windows.Forms.LinkLabel GiteeLlinkLable;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

