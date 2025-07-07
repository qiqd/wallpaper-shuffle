using System;
using System.Runtime.InteropServices;

namespace WallpaperShuffle
{
    /// <summary>
    /// 该类用来处理系统主题变更的通知。
    /// </summary>
    public static class NotifySysChangeTheme
    {
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);

        // SendMessageTimeout函数的声明
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessageTimeout(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            string lParam,
            uint fuFlags,
            uint uTimeout,
            out IntPtr lpdwResult);

        /// <summary>
        /// 通知系统刷新主题。
        /// </summary>
        public static void RefreshTheme()
        {
            const uint WM_SETTINGCHANGE = 0x001A;
            const uint SMTO_ABORTIFHUNG = 0x0002;

            IntPtr result;
            SendMessageTimeout(
                (IntPtr)0xFFFF, // HWND_BROADCAST，广播给所有顶级窗口
                WM_SETTINGCHANGE,
                IntPtr.Zero,
                "ImmersiveColorSet", // 通知系统主题更改
                SMTO_ABORTIFHUNG,
                5000,
                out result);
        }
    }
}