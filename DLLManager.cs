using System;
using System.Runtime.InteropServices;

namespace WallpaperShuffle
{
    internal class DLLManager
    {
        //修改窗口圆角 api
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);
        // 定义 DWM_WINDOW_CORNER_PREFERENCE 枚举
        private enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,      // 默认（系统决定）
            DWMWCP_DONOTROUND = 1,  // 禁用圆角
            DWMWCP_ROUND = 2,       // 启用圆角
            DWMWCP_ROUNDSMALL = 3   // 小圆角
        }
        public static void WindowRoundedCornersHandle(IntPtr handle)
        {
            const int DWMWA_WINDOW_CORNER_PREFERENCE = 33; // 属性ID
            int cornerPreference = (int)DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUNDSMALL; // 圆角样式
            DwmSetWindowAttribute(handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));

        }
    }
}
