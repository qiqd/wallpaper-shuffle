using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WallpaperShuffle
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            //判断多开
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = (Exception)e.ExceptionObject;
                MessageBox.Show($"发生未处理异常: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"未处理异常: {ex}");
            };
            if (processes.Length >= 2)
            {
                MessageBox.Show("程序已在运行，请勿重复启动！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(Environment.ExitCode);
            }
            //判断是否是自启动
            bool selfStarting = args.Any(item => item.Contains("autoStart"));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(selfStarting));
        }
    }
}