using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class PreloadWallpaperJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            WallpaperSourceItem item = WallpaperResource.WallpaperSourceItems[Properties.Settings.Default.currentIndex];
            string url = item.url;
            if (item.arguments != null && item.arguments.Length != 0)
            {
                url += "?";
                foreach (string param in item.arguments)
                {
                    url += "&" + param;
                }
            }

            WallpaperResource.DownloadAndSaveImageAsync(url);
            return Task.CompletedTask;
        }
    }
}