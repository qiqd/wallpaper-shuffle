using System;
using System.Runtime.InteropServices;

namespace WallpaperShuffle
{
    internal class DLLManager
    {
        // 定义 Windows API 常量和函数，修改注册表之后用来通知所有窗口
        private const int HWND_BROADCAST = 0xffff;

        private const uint WM_SETTINGCHANGE = 0x001A;
        private const uint SMTO_NORMAL = 0x0002;
        private const uint TIMEOUT = 100;

        private enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,      // 默认（系统决定）
            DWMWCP_DONOTROUND = 1,  // 禁用圆角
            DWMWCP_ROUND = 2,       // 启用圆角
            DWMWCP_ROUNDSMALL = 3   // 小圆角
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessageTimeout(
            IntPtr hWnd,
            uint Msg,
            UIntPtr wParam,
            string lParam,
            uint fuFlags,
            uint uTimeout,
            out IntPtr lpdwResult);

        //修改窗口圆角 api
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode)]
        public static extern void DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);

        public static void WindowRoundedCornersHandle(IntPtr handle)
        {
            const int DWMWA_WINDOW_CORNER_PREFERENCE = 33; // 属性ID
            int cornerPreference = (int)DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUNDSMALL; // 圆角样式
            DwmSetWindowAttribute(handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));
        }

        public static void SendMessageToAllWindows(string section)
        {
            IntPtr result;
            IntPtr hwndBroadcast = new IntPtr(HWND_BROADCAST);

            // 发送 WM_SETTINGCHANGE 消息
            SendMessageTimeout(
                hwndBroadcast,
                WM_SETTINGCHANGE,
                UIntPtr.Zero,
                section,
                SMTO_NORMAL,
                TIMEOUT,
                out result);
        }
    }
}