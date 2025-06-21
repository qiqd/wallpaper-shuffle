using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WallpaperShuffle
{
    internal class RegisterHandle
    {
        private readonly string appName = Process.GetCurrentProcess().ProcessName;
        private const string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string SliderInterval = @"Control Panel\Personalization\Desktop Slideshow";

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        private const uint SPI_SETDESKWALLPAPER = 0x0014;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        // 刷新壁纸相关设置

        public void LoadInterval()
        {
            // 打开注册表项
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SliderInterval))
            {
                if (key == null) return;
                // 获取 Interval 值
                object intervalValue = key.GetValue("Interval");
                if (intervalValue == null) return;
                Properties.Settings.Default.IntervalMinutes = Convert.ToInt32(intervalValue) / 60000;
                Properties.Settings.Default.Save();
            }
        }

        public void ChangeInterval(int newInterval)
        {
            // 打开注册表项
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SliderInterval, true))
            {
                if (key == null) return;
                key.SetValue("Interval", newInterval);
                SystemParametersInfo(0, 0, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        public bool SetStartup()
        {
            using (RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                if (startupKey.GetValue(appName) == null)
                {
                    string path = $"\"{System.Windows.Forms.Application.ExecutablePath}\" /autoStarting";
                    startupKey.SetValue(appName, path);
                    return false;
                }
                return true;
            }
        }

        public void RemoveStartup()
        {
            using (RegistryKey startupKey = Registry.CurrentUser.OpenSubKey(runKey, true))
            {
                // 检查是否存在当前应用程序的启动项
                if (startupKey.GetValue(appName) != null)
                {
                    // 删除该启动项
                    startupKey.DeleteValue(appName);
                }
            }
        }
    }
}