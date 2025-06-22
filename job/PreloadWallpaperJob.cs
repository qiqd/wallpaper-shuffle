using Quartz;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class PreloadWallpaperJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            int count = WallpaperResource.WallpaperSourceItems.Count;
            int currentIndex = Properties.Settings.Default.currentIndex;
            WallpaperSourceItem item = WallpaperResource.WallpaperSourceItems[currentIndex >= count ? 0 : currentIndex];
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