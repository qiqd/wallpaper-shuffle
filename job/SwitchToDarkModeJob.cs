using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle.job
{
    /// <summary>
    /// 改变系统主题为深色模式的作业。
    /// </summary>
    internal class SwitchToDarkModeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            RegisterHandle.ChangeModeToLight(false);
            return Task.CompletedTask;
        }
    }
}