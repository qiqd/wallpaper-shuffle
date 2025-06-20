using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class PreloadWallpaperJob : IJob
    {
        private readonly WallpaperResourcseManagement management;

        public PreloadWallpaperJob(WallpaperResourcseManagement management)
        {
            this.management = management;
        }

        public Task Execute(IJobExecutionContext context)
        {
            management.preLoadWallpaper();
            return Task.CompletedTask;
        }
    }
}