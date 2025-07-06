using Microsoft.Win32;

namespace WallpaperShuffle
{
    /// <summary>
    /// 用来检查系统主题是否为暗黑模式的帮助类。
    /// </summary>
    internal class SystemThemeHelper
    {
        public static bool IsSystemInDarkMode()
        {
            using (var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
            {
                if (key != null)
                {
                    var value = key.GetValue("AppsUseLightTheme");
                    if (value is int themeValue)
                    {
                        return themeValue == 0;
                    }
                }
            }
            return false;
        }
    }
}