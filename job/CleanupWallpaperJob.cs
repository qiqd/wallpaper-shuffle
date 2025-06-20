using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class CleanupWallpaperJob : IJob
    {
        private readonly WallpaperResourcseManagement management;

        public CleanupWallpaperJob(WallpaperResourcseManagement management)
        {
            this.management = management;
        }

        public Task Execute(IJobExecutionContext context)
        {
            management.cleanOldWallpaper();
            return Task.CompletedTask;
        }
    }
}