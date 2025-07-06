using Quartz;
using Quartz.Impl;
using System;
using System.IO;
using WallpaperShuffle.job;

namespace WallpaperShuffle
{
    /// <summary>
    /// 自动切换深色模式的调度类。
    /// </summary>
    internal class AutoChangeDarkTask
    {
        //是否启用置顶窗口
        internal bool enablePin = Properties.Settings.Default.EnableWindowsTopMost;

        //默认的触发时间
        internal static DateTime lightStart = Properties.Settings.Default.LightStart;

        internal static DateTime darkStart = Properties.Settings.Default.DarkStart;

        // 创建调度器
        internal IScheduler scheduler;

        internal string userPath;
        internal string appFolder;
        internal MainForm mainForm { get; set; }
        internal static IntPtr mainFormHandle { get; set; }

        public AutoChangeDarkTask()
        {
            //Environment.SpecialFolder.Programs
            this.userPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            this.appFolder = Path.Combine(userPath, "AutoDarkMin");
            //LoadSettings();
            InitializeSchedule();
        }

        internal async void InitializeSchedule()
        {
            this.scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            // 创建深色模式作业
            IJobDetail darkJob = JobBuilder.Create<SwitchToDarkModeJob>()
                .WithIdentity("JobToDark", "group1")
                .Build();

            // 创建浅色模式作业
            IJobDetail lightJob = JobBuilder.Create<SwitchToLightModeJob>()
                .WithIdentity("JobToLight", "group1") // 同一个组也可以
                .Build();

            // 创建深色模式触发器
            ITrigger darkTrigger = TriggerBuilder.Create()
                .WithIdentity("darkTrigger", "group1")
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(darkStart.Hour, darkStart.Minute))
                .Build();

            // 创建浅色模式触发器
            ITrigger lightTrigger = TriggerBuilder.Create()
                .WithIdentity("lightTrigger", "group1") // 触发器名称需要唯一
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(lightStart.Hour, lightStart.Minute))
                .Build();
            bool darktriggerExists = await scheduler.CheckExists(new TriggerKey("darkTrigger", "group1"));
            bool lighttriggerExists = await scheduler.CheckExists(new TriggerKey("lightTrigger", "group1"));
            if (!darktriggerExists || !lighttriggerExists)
            {
                // 如果触发器不存在，则添加到调度器
                if (!darktriggerExists)
                {
                    await scheduler.ScheduleJob(darkJob, darkTrigger);
                }
                if (!lighttriggerExists)
                {
                    await scheduler.ScheduleJob(lightJob, lightTrigger);
                }
            }
            else
            {
                // 如果触发器已存在，则替换触发器
                await scheduler.RescheduleJob(new TriggerKey("darkTrigger", "group1"), darkTrigger);
                await scheduler.RescheduleJob(new TriggerKey("lightTrigger", "group1"), lightTrigger);
            }
        }

        //public void SaveSettings()
        //{
        //    UserInfo userInfo = new UserInfo() { start = lightStart, end = darkStart, enablePin = enablePin };
        //    string v = JsonSerializer.Serialize(userInfo);

        //    if (!Directory.Exists(appFolder))
        //    {
        //        Directory.CreateDirectory(appFolder);
        //    }

        //    File.WriteAllText(appFolder + "\\setting.json", v);
        //}

        //public void LoadSettings()
        //{
        //    try
        //    {
        //        UserInfo? userInfo = JsonSerializer.Deserialize<UserInfo>(File.ReadAllText(appFolder + "\\setting.json"));
        //        lightStart = userInfo!.start ?? new TimeSpan(6, 0, 0);
        //        darkStart = userInfo.end ?? new TimeSpan(20, 0, 0);
        //        enablePin = userInfo.enablePin;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        //MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        if (File.Exists(appFolder + "\\setting.json"))
        //        {
        //            File.Delete("setting.json");
        //        }
        //    }
        //}
    }
}