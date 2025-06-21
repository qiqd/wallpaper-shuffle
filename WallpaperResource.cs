using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;

namespace WallpaperShuffle
{
    internal class WallpaperResource
    {
        public static string errLogPath = Path.Combine(Environment.CurrentDirectory, "error.log");
        public static List<WallpaperSourceItem> WallpaperSourceItems;
        public static string WallpaperSaveDirPath = Path.Combine(Environment.CurrentDirectory, "wallpaper");
        public static string WallpaperSourcesPath = Path.Combine(Environment.CurrentDirectory, "wallpaperSource.json");

        static WallpaperResource()
        {
            string saveDirPath = Properties.Settings.Default.WallpaperSaveDirPath;
            if (!string.IsNullOrEmpty(saveDirPath) && Directory.Exists(saveDirPath))
            {
                WallpaperSaveDirPath = saveDirPath;
            }
            else
            {
                Properties.Settings.Default.WallpaperSaveDirPath = WallpaperSaveDirPath;
                Properties.Settings.Default.Save();
            }
        }

        public static WallpaperSourceItem LoadWallpaperResources()
        {
            string currentTitle = Properties.Settings.Default.ResourceTitle;

            try
            {
                string values = File.ReadAllText(WallpaperSourcesPath);
                WallpaperSourceItems = JsonConvert.DeserializeObject<List<WallpaperSourceItem>>(values);
                WallpaperSourceItem item = WallpaperSourceItems.Find(i => i.title.Equals(currentTitle != "" ? currentTitle : "Bing每日随机壁纸"));
                return item;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("无法加载壁纸资源，请检查文件格式或内容是否正确。");
                File.AppendAllText(errLogPath, $"无法加载壁纸资源: {ex.Message}\n{ex.StackTrace}\\n");
                WallpaperSourceItem sourceItem = new WallpaperSourceItem() { title = "Bing每日随机壁纸", url = "https://bing.img.run/rand_uhd.php" };
                WallpaperSourceItems = new List<WallpaperSourceItem>() { sourceItem };
                string json = JsonConvert.SerializeObject(WallpaperSourceItems);
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "wallpaperSource.json"), json);
                return sourceItem;
            }
        }

        public static async void DownloadAndSaveImageAsync(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // 1. 获取响应流
                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        // 2. 判断图片类型（通过文件头识别更可靠）
                        string fileExtension = GetImageFileExtension(responseStream);

                        if (string.IsNullOrEmpty(fileExtension))
                        {
                            throw new InvalidDataException("无法识别图片格式");
                        }

                        // 3. 重置流位置以便后续读取
                        responseStream.Position = 0;
                        long unixTimestampSeconds = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

                        // 4. 生成文件名（例如：image-20250620.png）
                        string fileName = WallpaperSaveDirPath + $"\\{unixTimestampSeconds}.{fileExtension}";

                        // 5. 保存文件
                        using (FileStream fileStream = File.Create(fileName))
                        {
                            await responseStream.CopyToAsync(fileStream);
                        }

                        Debug.WriteLine($"图片已保存为：{fileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(errLogPath, $"下载图片失败: {ex.Message}\n{ex.StackTrace}\n URL:{url}");
            }
        }

        private static string GetImageFileExtension(Stream stream)
        {
            byte[] buffer = new byte[12]; // 扩展为12字节以支持 WebP 的判断
            int read = stream.Read(buffer, 0, 12);
            if (read < 12) return null;

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
    }
}