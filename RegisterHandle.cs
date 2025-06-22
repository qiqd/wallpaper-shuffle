using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    internal class RegisterHandle
    {
        private const string TaskName = "WallpaperShuffleAutoStart";

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

        // 注册开机自启动任务
        public void RegisterTask()
        {
            using (TaskService ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "开机自启动每日随机壁纸应用。";

                // 触发器：用户登录时
                td.Triggers.Add(new LogonTrigger { UserId = Environment.UserName });

                // 动作：启动当前应用程序
                string appPath = Application.ExecutablePath;
                td.Actions.Add(new ExecAction(appPath, "autoStart", null));

                // 设置任务以最高权限运行
                td.Principal.RunLevel = TaskRunLevel.Highest;

                // 设置兼容性
                td.Settings.Compatibility = TaskCompatibility.V2_1;

                // 注册任务
                ts.RootFolder.RegisterTaskDefinition(TaskName, td);
            }
        }

        // 删除任务
        public void UnregisterTask()
        {
            using (TaskService ts = new TaskService())
            {
                if (ts.RootFolder.Tasks.Exists(TaskName))
                {
                    ts.RootFolder.DeleteTask(TaskName);
                }
            }
        }
    }
}