﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    public partial class WallpaperShuffle : Form
    {
        private readonly bool selfStaring;
        private Random random = new Random();
        private readonly string CurrentInstancePath = AppDomain.CurrentDomain.BaseDirectory;
        private readonly WallpaperShuffleTask slidehowManager;
        private readonly RegisterHandle registerHandle;

        public WallpaperShuffle(bool selfStaring) : this()
        {
            WallpaperResource.LoadWallpaperResources();
            this.selfStaring = selfStaring;
            this.slidehowManager = new WallpaperShuffleTask();

            this.WallpaperSaveDirTextBox.Text = WallpaperResource.WallpaperSaveDirPath;
            DLLManager.WindowRoundedCornersHandle(this.WallpaperShuffleContextMenuStrip.Handle);
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            if (selfStaring)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                base.SetVisibleCore(false);
            }

            this.registerHandle.LoadInterval();
            this.slidehowManager.InitScheduler();
            this.AutoBootCheckBox.Checked = Properties.Settings.Default.AutoBoot;
            this.AutoPlayIntervals.Value = Properties.Settings.Default.IntervalMinutes;
            this.CleanupInterval.Value = Properties.Settings.Default.CleanupIntervalMinutes;
            this.Invoke(new Action(() =>
            {
                foreach (var item in WallpaperResource.WallpaperSourceItems)
                {
                    this.WallpaperSourceComboBox.Items.Add(item.title);
                }
            }));
            this.WallpaperSourceComboBox.SelectedIndex = Properties.Settings.Default.currentIndex;
            Properties.Settings.Default.Save();
            this.slidehowManager.InitPreloadTrigger();
            this.slidehowManager.InitCleanupTrigger();
        }

        private void OnWallpaperCategoryComboBoxChange(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Properties.Settings.Default.currentIndex = comboBox.SelectedIndex;
            Properties.Settings.Default.Save();
            // 更新壁纸资源之后，立即删除旧壁纸
            WallpaperResource.DeleteWallpaperWhenIndexChanged();
        }

        private void ChangeWallpaperSorcesFIle(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(CurrentInstancePath, "wallpaperSource.json");
                // 确保路径被引号包裹
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = path,
                    UseShellExecute = false
                };
                Process process = Process.Start(processStartInfo);
                if (process == null)
                {
                    MessageBox.Show("无法打开壁纸配置文件，请检查文件是否存在。");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("打开壁纸配置文件失败。");
            }
        }

        private void ChangeWallpaperSaveDir(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择一个用来保存下载壁纸的文件夹";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.Cancel) return;
            Properties.Settings.Default.WallpaperSaveDirPath = folderBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
            WallpaperResource.WallpaperSaveDirPath = folderBrowserDialog.SelectedPath;
        }

        private void RestoreDefaultSetting(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定要恢复默认设置吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No) return;

            Properties.Settings.Default.Reset();
            WallpaperResource.LoadWallpaperResources();
            WallpaperResource.WallpaperSaveDirPath = Path.Combine(CurrentInstancePath, "wallpaper");
        }

        private void EnableAutoBoot(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Properties.Settings.Default.AutoBoot = checkBox.Checked;
            Properties.Settings.Default.Save();
            if (checkBox.Checked)
            {
                //this.registerHandle.RegisterTask();
                this.registerHandle.RegisterAutoStart();
            }
            else
            {
                //this.registerHandle.UnregisterTask();
                this.registerHandle.UnregisterAutoStart();
            }
        }

        private void EnableAutoCleanup(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Properties.Settings.Default.AutoCleanup = checkBox.Checked;
            Properties.Settings.Default.Save();
            if (!checkBox.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("关闭自动清理功能后，程序将不再定期删除旧壁纸文件。是否关闭自动清理功能？。", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Cancel)
                {
                    checkBox.Checked = true;
                    return;
                }
                this.slidehowManager.PauseCleanupTrigger();
            }
            else
            {
                this.slidehowManager.ResumeCleanupTrigger();
            }
        }

        private void ShowLogFile(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(CurrentInstancePath, "error.log");
                ProcessStartInfo processStartInfo = new ProcessStartInfo { FileName = "notepad.exe", Arguments = path, UseShellExecute = false };
                //processStartInfo.
                Process.Start(processStartInfo);
            }
            catch (Exception)
            {
                MessageBox.Show("打开错误日志文件失败。");
            }
        }

        private void UsageGuideClick(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(CurrentInstancePath, "UsageGuide.md");
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = path,
                    UseShellExecute = false
                };
                Process process = Process.Start(processStartInfo);
                if (process == null)
                {
                    MessageBox.Show("无法打开使用指导文件，请检查文件是否存在。");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("打开使用指导文件失败。");
            }
        }

        private void WallpaperSourceChange(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Properties.Settings.Default.currentIndex = comboBox.SelectedIndex;
            Properties.Settings.Default.ResourceTitle = WallpaperResource.WallpaperSourceItems[comboBox.SelectedIndex].title;
            Properties.Settings.Default.Save();
        }

        private void LanguageShowChange(object sender, EventArgs e)
        {
        }

        private void ShowMainFormStrip(object sender, EventArgs e)
        {
            int index = random.Next(0, 3);
            switch (index)
            {
                case 0: this.AboutPictureBox.Image = Properties.Resources.teto2; break;
                case 1: this.AboutPictureBox.Image = Properties.Resources.miku; break;
                case 2: this.AboutPictureBox.Image = Properties.Resources.teto1; break;
                default: break;
            }
            this.AboutPictureBox.Refresh();
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            base.SetVisibleCore(true);
            this.Activate();
        }

        private void QuitAppStrip(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(Environment.ExitCode);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void OnIntervalCalueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            int value = (int)numericUpDown.Value;
            this.registerHandle.ChangeInterval(value * 60000);
            Properties.Settings.Default.IntervalMinutes = value;
            Properties.Settings.Default.Save();
            this.slidehowManager.OnInternalChange(value);
        }

        private void OnCleanupIntervalChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            int value = (int)numericUpDown.Value;
            Properties.Settings.Default.CleanupIntervalMinutes = value;
            Properties.Settings.Default.Save();
            this.slidehowManager.OnCleanupInternalChange(value);
        }

        private void ShowWallpaperSaveDir(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = WallpaperResource.WallpaperSaveDirPath,
                UseShellExecute = false
            };
            Process.Start(processStartInfo);
        }

        private void GiteeLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Properties.Settings.Default.GiteeLink,
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void GitHubLinkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Properties.Settings.Default.GitHubLink,
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}