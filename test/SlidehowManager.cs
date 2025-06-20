using Microsoft.Win32;
using Quartz;
using Quartz.Impl;
using System;
using WallpaperShuffle;

public class SlidehowManager
{
    private int IntervalMs = 60000; // 默认间隔时间为60秒
    private readonly IScheduler scheduler;

    private const string DesktopSlideshowKeyPath = @"Control Panel\Personalization\Desktop Slideshow";
    private const string WallpapersKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Wallpapers";
    private const string SliderInterval = @"Control Panel\Personalization\Desktop Slideshow";

    public SlidehowManager()
    {
        //ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        //IScheduler scheduler = await schedulerFactory.GetScheduler();
        ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
        this.scheduler = schedulerFactory.GetScheduler();
    }

    internal void LoadInterval()
    {
        // 打开注册表项
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SliderInterval))
        {
            if (key == null) return;
            // 获取 Interval 值
            object intervalValue = key.GetValue("Interval");
            if (intervalValue == null) return;
            this.IntervalMs = Convert.ToInt32(intervalValue);
        }
    }

    internal async void InitTrigger()
    {
        IJobDetail preloadJob = JobBuilder.Create<PreloadWallpaperJob>()
            .WithIdentity("PreloadWallpaperJob", "WallpaperGroup")
            .Build();
        IJobDetail cleanupOldJob = JobBuilder.Create<CleanupWallpaperJob>()
           .WithIdentity("CleanupWallpaperJob", "WallpaperGroup")
           .Build();
        ITrigger preloadTrigger = TriggerBuilder.Create()
            .WithIdentity("PreloadWallpaperTrigger", "WallpaperGroup")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(this.IntervalMs / 1000)// 将毫秒转换为秒
                .RepeatForever())
            .Build();
        ITrigger cleanupOldTrigger = TriggerBuilder.Create()
           .WithIdentity("CleanupOldTrigger", "WallpaperGroup")
           .StartNow()
           .WithSimpleSchedule(x => x
               .WithIntervalInHours(1) // 每小时清理一次
               .RepeatForever())
           .Build();
        await scheduler.ScheduleJob(preloadJob, preloadTrigger);
        await scheduler.ScheduleJob(cleanupOldJob, cleanupOldTrigger);
    }
}