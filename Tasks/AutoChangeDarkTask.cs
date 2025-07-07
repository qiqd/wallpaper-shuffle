using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
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
        internal DateTime lightStart = Properties.Settings.Default.LightStart;

        internal DateTime darkStart = Properties.Settings.Default.DarkStart;

        // 创建调度器
        internal IScheduler scheduler;

        internal WallpaperShuffle mainForm { get; set; }

        internal static IntPtr mainFormHandle { get; set; }

        public AutoChangeDarkTask()
        {
            Task.Run(async () =>
            {
                this.scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();
                InitializeSchedule();
            });
        }

        /// <summary>
        /// 允许外部调用来切换深色模式。
        /// </summary>
        /// <param name="turnoff"></param>
        internal void AutoDarkTaskSwitch(bool turnoff)
        {
            if (scheduler == null) return;
            if (turnoff == true)
            {
                scheduler.PauseAll();
            }
            else
            {
                scheduler.ResumeAll();
            }
        }

        /// <summary>
        /// 初始化调度任务。
        /// </summary>
        internal async void InitializeSchedule()
        {
            this.lightStart = Properties.Settings.Default.LightStart;
            this.darkStart = Properties.Settings.Default.DarkStart;
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
    }
}