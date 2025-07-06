using Quartz;
using Quartz.Impl;
using System;

namespace WallpaperShuffle
{
    public class WallpaperShuffleTask
    {
        private readonly int CleanupIntervalMinutes = Properties.Settings.Default.CleanupIntervalMinutes; // 默认清理间隔时间为30分钟
        private readonly int IntervalMinutes = Properties.Settings.Default.IntervalMinutes; // 默认间隔时间为5分钟
        public IScheduler scheduler;

        private const string CleanupWallpaperJobName = "CleanupWallpaperJob";
        private const string PreloadWallpaperJobName = "PreloadWallpaperJob";
        private const string PreloadWallpaperTriggerName = "PreloadWallpaperTrigger";
        private const string CleanupWallpaperTriggerName = "CleanupWallpaperTrigger";
        private const string WallpaperGroup = "WallpaperGroup";

        public async void InitScheduler()
        {
            this.scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await this.scheduler.Start();
        }

        // 初始化清理调度器
        public async void InitCleanupTrigger()
        {
            IJobDetail cleanupOldJob = JobBuilder.Create<CleanupWallpaperJob>()
               .WithIdentity(CleanupWallpaperJobName, WallpaperGroup)
               .Build();
            ITrigger cleanupOldTrigger = TriggerBuilder.Create()
             .WithIdentity(CleanupWallpaperTriggerName, WallpaperGroup)
             .StartAt(DateTime.UtcNow.AddSeconds(30)) // 30秒后开始
             .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(CleanupIntervalMinutes) // 设置清理间隔时间
                 .RepeatForever())
             .Build();
            await scheduler.ScheduleJob(cleanupOldJob, cleanupOldTrigger);
        }

        // 初始化壁纸调度器
        public async void InitPreloadTrigger()
        {
            IJobDetail preloadJob = JobBuilder.Create<PreloadWallpaperJob>()
                .WithIdentity(PreloadWallpaperJobName, WallpaperGroup)
                .Build();

            ITrigger preloadTrigger = TriggerBuilder.Create()
                .WithIdentity(PreloadWallpaperTriggerName, WallpaperGroup)
                .StartAt(DateTime.UtcNow.AddSeconds(10)) // 10秒后开始
                .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(IntervalMinutes * 60 - 30)
                    .RepeatForever())
                .Build();
            await scheduler.ScheduleJob(preloadJob, preloadTrigger);
        }

        // 重新加载壁纸调度器
        public async void OnInternalChange(int interval)
        {
            ITrigger newPreloadTrigger = TriggerBuilder.Create()
              .WithIdentity(PreloadWallpaperTriggerName, WallpaperGroup)
              .StartAt(DateTime.UtcNow.AddSeconds(10)) // 10秒后开始
              .WithSimpleSchedule(x => x
                 .WithIntervalInSeconds(interval * 60 - 30)
                  .RepeatForever())
              .Build();
            await this.scheduler.RescheduleJob(new TriggerKey(PreloadWallpaperTriggerName, WallpaperGroup), newPreloadTrigger);
        }

        public async void OnCleanupInternalChange(int interval)
        {
            ITrigger newCleanupOldTrigger = TriggerBuilder.Create()
             .WithIdentity(CleanupWallpaperTriggerName, WallpaperGroup)
             .StartAt(DateTime.UtcNow.AddSeconds(interval)) // 10秒后开始
             .WithSimpleSchedule(x => x
                .WithIntervalInMinutes(interval) // 设置清理间隔时间
                 .RepeatForever())
             .Build();
            await this.scheduler.RescheduleJob(new TriggerKey(CleanupWallpaperTriggerName, WallpaperGroup), newCleanupOldTrigger);
        }

        // 暂停触发器
        public async void PauseCleanupTrigger()
        {
            await scheduler.PauseTrigger(new TriggerKey(CleanupWallpaperTriggerName, WallpaperGroup));
        }

        // 恢复理触发器
        public async void ResumeCleanupTrigger()
        {
            await scheduler.ResumeTrigger(new TriggerKey(CleanupWallpaperTriggerName, WallpaperGroup));
        }
    }
}