using Quartz;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WallpaperShuffle
{
    internal class ShuffleWallpaperJob : IJob

    {
        public static string path { get; set; }

        // 导入 user32.dll 中的 SystemParametersInfo 函数
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;

        // 壁纸样式枚举
        public enum Style : int
        {
            Tiled,      // 平铺
            Centered,   // 居中
            Stretched,  // 拉伸（变形）
            Fit,        // 自动适应（保持比例，有黑边）
            Fill,       // 填充屏幕（保持比例，裁剪边缘）
            Span,       // 跨多显示器拼接（仅限 Win10/Win11 多显示器）
            NoChange    // 不更改当前设置
        }

        public Task Execute(IJobExecutionContext context)
        {
            Style style = Style.Fill;
            // 写注册表
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            switch (style)
            {
                case Style.Fill:
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

                case Style.Fit:
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

                case Style.Stretched:
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

                case Style.Centered:
                    key.SetValue(@"WallpaperStyle", "1");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

                case Style.Tiled:
                    key.SetValue(@"WallpaperStyle", "1");
                    key.SetValue(@"TileWallpaper", "1");
                    break;

                case Style.NoChange:
                    // 不改变当前样式
                    break;
            }

            key.Close();

            // 更新壁纸
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            return Task.CompletedTask;
        }
    }
}