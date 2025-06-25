using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    internal class RegisterHandle
    {
        //private const uint SPI_SETDESKWALLPAPER = 0x0014;
        //private const uint SPIF_UPDATEINIFILE = 0x01;
        //private const uint SPIF_SENDCHANGE = 0x02;

        //// 定义 Windows API 常量和函数
        //private const int HWND_BROADCAST = 0xffff;

        //private const uint WM_SETTINGCHANGE = 0x001A;
        //private const uint SMTO_NORMAL = 0x0002;
        //private const uint TIMEOUT = 100;
        private const string TaskName = "WallpaperShuffleAutoStart";

        private const string SliderInterval = @"Control Panel\Personalization\Desktop Slideshow";
        private const string AppName = "WallpaperShuffle";

        // 获取当前可执行文件的路径
        private string appPath = $"\"{Application.ExecutablePath}\" /autoStart";

        // 注册表项路径（当前用户）
        private const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        // 加载壁纸切换间隔相关设置
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

        public void RegisterAutoStart()
        {
            try
            {
                // 打开注册表项（HKEY_CURRENT_USER）
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
                {
                    if (key == null)
                    {
                        Console.WriteLine("无法打开注册表项！");
                        return;
                    }

                    // 设置自启动键值（名称可以自定义，例如 "MyApp"）
                    key.SetValue(AppName, appPath);

                    Console.WriteLine("已成功设置为开机自启动！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("设置自启动失败：" + ex.Message);
            }
        }

        public void UnregisterAutoStart()
        {
            try
            {
                // 打开注册表项（HKEY_CURRENT_USER）
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, true))
                {
                    if (key == null)
                    {
                        Console.WriteLine("无法打开注册表项！");
                        return;
                    }
                    // 删除自启动键值
                    key.DeleteValue(AppName, false);
                    Console.WriteLine("已成功取消开机自启动！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("取消自启动失败：" + ex.Message);
            }
        }

        public void ChangeInterval(int newInterval)
        {
            // 打开注册表项
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(SliderInterval, true))
            {
                if (key == null) return;
                key.SetValue("Interval", newInterval);
                //SystemParametersInfo(0, 0, IntPtr.Zero, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
                DLLManager.SendMessageToAllWindows(SliderInterval);
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