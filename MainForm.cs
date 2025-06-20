using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    public partial class MainForm : Form
    {
        private readonly WallpaperResourcseManagement wallpaperResourcseManagement;

        public MainForm(bool selfStaring)
        {
            InitializeComponent();
            Debug.WriteLine(GetSlideshowDuration());
            this.wallpaperResourcseManagement = new WallpaperResourcseManagement();
            this.Load += async (s, e) => await LoadWalpaperResources();
        }

        public int GetSlideshowDuration()
        {
            // 定义注册表路径和键名
            string registryPath = @"Control Panel\Desktop\Slideshow";
            string keyName = "Duration";

            // 打开注册表项
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath))
            {
                if (key != null)
                {
                    // 读取Duration值
                    object durationValue = key.GetValue(keyName);
                    if (durationValue != null)
                    {
                        return Convert.ToInt32(durationValue);
                    }
                }
            }

            // 如果没有找到值，返回默认值（例如：60秒）
            return 999;
        }

        private async Task LoadWalpaperResources()
        {
            List<WallpaperSource> wallpaperSources = await wallpaperResourcseManagement.readLocalWallpaperResources();
            if (wallpaperSources == null || wallpaperSources.Count == 0)
            {
                MessageBox.Show("没有可用的壁纸资源"); return;
            }
            this.BeginInvoke(new Action(() =>
            {
                wallpaperSources.ForEach(item =>
                {
                    Debug.WriteLine($"添加壁纸资源: {item.title}");
                    int index = this.WallpaperCategoryComboBox.Items.Add(item.title);
                });
                this.WallpaperCategoryComboBox.SelectedIndex = 0;
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WallpaperSource wallpaperSource = new WallpaperSource();
            wallpaperSource.title = "测试标题";
            wallpaperSource.url = "https://example.com/wallpaper.jpg";
            wallpaperSource.arguments = new string[] { "arg1", "arg2" };

            string json = JsonConvert.SerializeObject(wallpaperSource, Formatting.Indented);
            List<WallpaperSource> wallpaperSources = new List<WallpaperSource>();
            Debug.WriteLine(json);
            string current = Environment.CurrentDirectory;
            File.WriteAllText(current + "wallpaperSource.json", json);
        }

        private void OnWallpaperCategoryComboBoxChange(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            Properties.Settings.Default.currentIndex = comboBox.SelectedIndex;
            Properties.Settings.Default.Save();
            //wallpaperResourcseManagement.updateWallpaperSources();
        }
    }
}