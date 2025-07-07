using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle.job
{
    /// <summary>
    /// 改变系统主题为浅色模式的作业。
    /// </summary>
    internal class SwitchToLightModeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            RegisterHandle.ChangeModeToLight(true);
            return Task.CompletedTask;
        }
    }
}