using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    internal class WallpaperResourcseManagement
    {
        private int index = 0;

        //public string wallpaperDirectory { get; set; }
        private string currentDirectory = Environment.CurrentDirectory;

        private string wallpaperFloderPath;

        public WallpaperResourcseManagement()
        {
            this.wallpaperFloderPath = Path.Combine(currentDirectory, "wallpaper");
            this.createWallpaperFloder();
        }

        /// <summary>
        ///    读取本地壁纸资源，如果不存在则创建一个默认的壁纸资源。
        /// </summary>
        /// <returns>壁纸资源 </returns>
        /// <exception cref="Exception"></exception>
        internal async Task<List<WallpaperSource>> readLocalWallpaperResources()
        {
            string filePath = Path.Combine(currentDirectory, "wallpaperSource.json");
            if (File.Exists(filePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        string json = await reader.ReadToEndAsync();
                        return JsonConvert.DeserializeObject<List<WallpaperSource>>(json);
                    }

                    Debug.WriteLine("壁纸资源加载成功");
                }
                catch (Exception ex)
                {
                    // 异常处理
                    File.Delete(filePath);
                    MessageBox.Show($"加载壁纸资源失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine($"加载壁纸资源失败: {ex.Message}");
                    return null;
                }
            }
            else
            {
                // 如果文件不存在，创建一个默认的壁纸资源
                WallpaperSource wallpaperSource = new WallpaperSource();
                wallpaperSource.title = "Bing随机壁纸";
                wallpaperSource.url = "https://bing.img.run/rand_uhd.php";

                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        await writer.WriteAsync(JsonConvert.SerializeObject(new List<WallpaperSource> { wallpaperSource }, Formatting.Indented));
                        return new List<WallpaperSource> { wallpaperSource };
                    }

                    Debug.WriteLine("壁纸资源加载成功");
                    // 这里可以处理加载的壁纸资源
                }
                catch (Exception ex)
                {
                    // 异常处理
                    MessageBox.Show($"创建默认壁纸资源失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine($"创建默认壁纸资源失败: {ex.Message}");
                    throw new Exception("创建默认壁纸资源失败", ex);
                }
            }
        }

        internal void createWallpaperFloder()
        {
            if (Directory.Exists(wallpaperFloderPath)) return;
            Directory.CreateDirectory(wallpaperFloderPath);
        }

        internal async void configureScheduler(int intervalMinutes)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();

            // 预加载壁纸任务
            IJobDetail preloadJob = JobBuilder.Create<PreloadWallpaperJob>()
                .WithIdentity("preloadJob", "wallpaper")
                .Build();

            ITrigger preloadTrigger = TriggerBuilder.Create()
                .WithIdentity("preloadTrigger", "wallpaper")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds((intervalMinutes * 60) - 60) // 提前 60 秒
                    .RepeatForever())
                .Build();

            // 更换壁纸任务
            IJobDetail changeJob = JobBuilder.Create<ShuffleWallpaperJob>()
                .WithIdentity("changeJob", "wallpaper")
                .Build();

            ITrigger changeTrigger = TriggerBuilder.Create()
                .WithIdentity("changeTrigger", "wallpaper")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(intervalMinutes)
                    .RepeatForever())
                .Build();

            // 清理壁纸任务
            IJobDetail cleanupJob = JobBuilder.Create<CleanupWallpaperJob>()
                .WithIdentity("cleanupJob", "wallpaper")
                .Build();

            ITrigger cleanupTrigger = TriggerBuilder.Create()
                .WithIdentity("cleanupTrigger", "wallpaper")
                .WithCronSchedule("0 0 0 * * ?")  // 每天凌晨 0 点执行
                .Build();

            await scheduler.ScheduleJob(preloadJob, preloadTrigger);
            await scheduler.ScheduleJob(changeJob, changeTrigger);
            await scheduler.ScheduleJob(cleanupJob, cleanupTrigger);

            await scheduler.Start();
        }

        internal void updateWallpaperSources()
        {
        }

        internal void shuffleWallpaper()
        {
        }

        internal void cleanOldWallpaper()
        {
        }

        internal void preLoadWallpaper()
        {
        }

        internal void ChangedWallpaper()
        {
            string tempPath = null;

            string[] filesName = Directory.GetFiles(wallpaperFloderPath);
            foreach (var item in filesName)
            {
                tempPath = item;
            }
            if (filesName.Length == 0) return;
            for (int i = 0; i < filesName.Length; i++)
            {
                Debug.WriteLine($"壁纸文件: {filesName[i]}");
            }
            Debug.WriteLine(wallpaperFloderPath + "::path");
            WallpaperSlidehowManager.SetSlideshow(wallpaperFloderPath, 20000, true);

            //Form tempForm = new Form()
            //{
            //    FormBorderStyle = FormBorderStyle.None,
            //    StartPosition = FormStartPosition.Manual,
            //    Location = new System.Drawing.Point(0, 0),
            //    Size = Screen.PrimaryScreen.Bounds.Size,
            //    BackgroundImage = System.Drawing.Image.FromFile(filesName[0]),
            //    WindowState = FormWindowState.Maximized,
            //    Visible = true,
            //    TopMost = true,
            //};
            //tempForm.Show();
            //if (index >= filesName.Length) index = 0;
            //Test.path = filesName[index++];
            //Test test = new Test();
            //test.Execute();
            //for (int i = 0; i < 100; i++)
            //{
            //    tempForm.Opacity = 0.1 * i;
            //    System.Threading.Thread.Sleep(100);
            //}
            //tempForm.Dispose();
            //tempForm.Close();
        }
    }
}