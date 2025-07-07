using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace WallpaperShuffle
{
    /// <summary>
    /// 该类用于管理壁纸资源，包括加载、下载和保存壁纸。
    /// </summary>
    internal class WallpaperResource
    {
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
        public static List<WallpaperSourceItem> WallpaperSourceItems;
        public static string WallpaperSaveDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wallpaper");
        public static string WallpaperSourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wallpaperSource.json");

        static WallpaperResource()
        {
            string saveDirPath = Properties.Settings.Default.WallpaperSaveDirPath;
            if (!string.IsNullOrEmpty(saveDirPath) && Directory.Exists(saveDirPath))
            {
                WallpaperSaveDirPath = saveDirPath;
            }
            else
            {
                if (!Directory.Exists(WallpaperSaveDirPath)) Directory.CreateDirectory(WallpaperSaveDirPath);
                Properties.Settings.Default.WallpaperSaveDirPath = WallpaperSaveDirPath;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 加载壁纸资源列表。
        /// </summary>
        /// <returns>获取到的壁纸资源</returns>
        public static WallpaperSourceItem LoadWallpaperResources()
        {
            string currentTitle = Properties.Settings.Default.ResourceTitle;

            try
            {
                string values = File.ReadAllText(WallpaperSourcesPath);
                WallpaperSourceItems = JsonConvert.DeserializeObject<List<WallpaperSourceItem>>(values);
                int currentIndex = Properties.Settings.Default.currentIndex;
                if (currentIndex >= WallpaperSourceItems.Count)
                {
                    Properties.Settings.Default.currentIndex = 0;
                    Properties.Settings.Default.Save();
                }
                WallpaperSourceItem item = WallpaperSourceItems.Find(i => i.title.Equals(currentTitle != "" ? currentTitle : "Bing每日随机壁纸"));
                return item;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("无法加载壁纸资源，请检查文件格式或内容是否正确。");
                File.AppendAllText(path, $"无法加载壁纸资源: {ex.Message}\n{ex.StackTrace}\\n");
                WallpaperSourceItem sourceItem = new WallpaperSourceItem() { title = "Bing每日随机壁纸", url = "https://bing.img.run/rand_uhd.php" };
                WallpaperSourceItems = new List<WallpaperSourceItem>() { sourceItem };
                string json = JsonConvert.SerializeObject(WallpaperSourceItems);
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wallpaperSource.json"), json);
                return sourceItem;
            }
        }

        /// <summary>
        /// 异步下载并保存图片到指定目录。
        /// </summary>
        /// <param name="url">壁纸下载的url</param>
        public static async void DownloadAndSaveImageAsync(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // 使用 ResponseHeadersRead 避免缓冲整个响应
                    using (HttpResponseMessage response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();

                        using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                        {
                            // 1. 读取文件头判断图片类型
                            byte[] headerBytes = new byte[12];
                            int bytesRead = await responseStream.ReadAsync(headerBytes, 0, headerBytes.Length);

                            if (bytesRead < 4)
                                throw new InvalidDataException("图片数据太小，无法识别");

                            string fileExtension = GetImageFileExtension(headerBytes);
                            if (string.IsNullOrEmpty(fileExtension))
                                throw new InvalidDataException("无法识别图片格式");

                            // 2. 构造文件名
                            long unixTimestampSeconds = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
                            string fileName = Path.Combine(WallpaperSaveDirPath, $"{unixTimestampSeconds}.{fileExtension}");

                            // 3. 创建文件流并写入已读取的头部
                            using (FileStream fileStream = File.Create(fileName))
                            {
                                await fileStream.WriteAsync(headerBytes, 0, bytesRead);

                                // 4. 流式复制剩余内容（避免整张图进入内存）
                                await responseStream.CopyToAsync(fileStream);
                                DLLManager.SendMessageToAllWindows("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Wallpapers");
                            }

                            Debug.WriteLine($"---{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}--- 图片已保存为：{fileName}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string logMessage = $"下载图片失败: {ex.Message}\n{ex.StackTrace}\nURL:{url}\n";
                File.AppendAllText(path, logMessage);
            }
        }

        /// <summary>
        /// 获取图片文件扩展名。
        /// </summary>
        /// <param name="buffer">图片对应的byte数组</param>
        /// <returns>图片拓展名</returns>
        private static string GetImageFileExtension(byte[] buffer)
        {
            // JPEG: starts with FF D8 FF
            if (buffer[0] == 0xFF && buffer[1] == 0xD8 && buffer[2] == 0xFF)
                return "jpg";

            // PNG: 89 50 4E 47 0D 0A 1A 0A
            if (buffer[0] == 0x89 && buffer[1] == 0x50 && buffer[2] == 0x4E && buffer[3] == 0x47)
                return "png";

            // GIF: 47 49 46 38
            if (buffer[0] == 0x47 && buffer[1] == 0x49 && buffer[2] == 0x46 && buffer[3] == 0x38)
                return "gif";

            // BMP: 42 4D
            if (buffer[0] == 0x42 && buffer[1] == 0x4D)
                return "bmp";

            // TIFF: 49 49 2A 00 or 4D 4D 00 2A
            if ((buffer[0] == 0x49 && buffer[1] == 0x49 && buffer[2] == 0x2A) ||
                (buffer[0] == 0x4D && buffer[1] == 0x4D && buffer[2] == 0x00 && buffer[3] == 0x2A))
                return "tiff";

            // WebP: 52 49 46 46 xx xx xx xx 57 45 42 50
            if (buffer[0] == 0x52 && buffer[1] == 0x49 && buffer[2] == 0x46 && buffer[3] == 0x46 &&
                buffer[8] == 0x57 && buffer[9] == 0x45 && buffer[10] == 0x42 && buffer[11] == 0x50)
                return "webp";

            return null;
        }

        /// <summary>
        /// 当壁纸索引改变时，删除之前保存的壁纸文件。
        /// </summary>
        public static void DeleteWallpaperWhenIndexChanged()
        {
            string wallpaperSaveDirPath = Properties.Settings.Default.WallpaperSaveDirPath;
            string currentWallpaperPath = DLLManager.GetCurrentWallpaperPath();
            string name = new FileInfo(currentWallpaperPath).Name;
            string[] path = Directory.GetFiles(wallpaperSaveDirPath);
            path.Where(item => !item.Contains(name)).ToList().ForEach(item =>
             {
                 try
                 {
                     File.Delete(item);
                 }
                 catch (Exception ex)
                 {
                     string logMessage = $"删除壁纸失败: {ex.Message}\n{ex.StackTrace}\n文件路径: {item}\n";
                     File.AppendAllText(item, logMessage);
                 }
             });
        }
    }
}