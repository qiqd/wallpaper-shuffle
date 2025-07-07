using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    /// <summary>
    /// 用来处理注册表相关操作的类，比如设置开机自启动、修改壁纸切换间隔等。
    /// </summary>
    internal class RegisterHandle
    {
        public static WallpaperShuffle mainForm { get; set; }

        // 任务名称
        private const string TaskName = "WallpaperShuffleAutoStart";

        // 壁纸切换间隔的注册表路径
        private const string SliderInterval = @"Control Panel\Personalization\Desktop Slideshow";

        private const string AppName = "WallpaperShuffle";

        //自启动注册表路径
        private const string RunKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        //设置系统主题的注册表路径
        private const string ThemePath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        //应用程序主题的注册表键
        private const string AppsUseLightThemeKey = "AppsUseLightTheme";

        //系统主题的注册表键
        private const string SystemUsesLightThemeKey = "SystemUsesLightTheme";

        // 获取当前可执行文件的路径
        private string appPath = $"\"{Application.ExecutablePath}\" /autoStart";

        /// <summary>
        /// 加载壁纸切换间隔。
        /// </summary>
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

        /// <summary>
        /// 应用程序注册开机自启动。
        /// </summary>
        public void RegisterAutoStart()
        {
            try
            {
                // 打开注册表项（HKEY_CURRENT_USER）
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true))
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

        /// <summary>
        /// 应用程序取消开机自启动。
        /// </summary>
        public void UnregisterAutoStart()
        {
            try
            {
                // 打开注册表项（HKEY_CURRENT_USER）
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKeyPath, true))
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

        /// <summary>
        /// 改变壁纸切换间隔。
        /// </summary>
        /// <param name="newInterval">新的时间间隔</param>
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

        /// <summary>
        /// 通过 Windows 任务计划程序注册开机自启动任务。
        /// </summary>
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

        /// <summary>
        /// 通过 Windows 任务计划程序取消注册开机自启动任务。
        /// </summary>
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

        /// <summary>
        /// 改变系统主题模式（浅色或深色）。
        /// </summary>
        /// <param name="isLight">是否是浅色模式</param>
        /// <param name="handle">对应的窗口句柄</param>
        public static void ChangeModeToLight(bool isLight)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(ThemePath, true))
            {
                if (key == null)
                {
                    MessageBox.Show("无法打开注册表项");
                    return;
                }
                // 设置系统主题（如果支持）
                if (key.GetValue(SystemUsesLightThemeKey) != null)
                {
                    key.SetValue(SystemUsesLightThemeKey, isLight ? 1 : 0, RegistryValueKind.DWord);
                }

                // 设置应用程序主题
                key.SetValue(AppsUseLightThemeKey, isLight ? 1 : 0, RegistryValueKind.DWord);
                // 异步刷新系统主题
                mainForm.Invoke(new System.Action(() =>
                {
                    NotifySysChangeTheme.RefreshTheme();
                    int transparency = isLight ? 0 : 1; // 窗口深浅色模式，·1·为深色模式，·0·为浅色模式
                    NotifySysChangeTheme.DwmSetWindowAttribute(mainForm.Handle, 20, ref transparency, sizeof(int));
                }));
            }
        }
    }
}