using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class CleanupWallpaperJob : IJob
    {
        private static readonly HashSet<string> imageExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { ".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tiff", ".webp" };

        public Task Execute(IJobExecutionContext context)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "wallpaper");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            string[] imageFiles = Directory.GetFiles(path)
                .Where(f => imageExtensions.Contains(Path.GetExtension(f)))
                .ToArray();

            if (imageFiles.Length < 31) return Task.CompletedTask;
            // 按时间戳升序排序
            string[] sortedFiles = imageFiles
                .Select(f => new
                {
                    FilePath = f,
                    Timestamp = Convert.ToInt64(Path.GetFileNameWithoutExtension(f))
                })
                .OrderBy(x => x.Timestamp) // 升序排列
                .Take(30) // 取前15个
                .Select(x => x.FilePath)
                .ToArray();
            try
            {
                foreach (string fileName in sortedFiles)
                {
                    //File.
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                string logPath = Path.Combine(Environment.CurrentDirectory, "error.log");
                File.AppendAllText(logPath, $"删除图片失败: {ex.Message}\n{ex.StackTrace}\n");
                throw new Exception(ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}