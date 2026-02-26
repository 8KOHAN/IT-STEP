using System.Runtime.InteropServices;

namespace WinApiHomework
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(
            IntPtr hWnd,
            string text,
            string caption,
            uint type);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(
            IntPtr parent,
            IntPtr childAfter,
            string className,
            string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            IntPtr hWnd,
            uint Msg,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern bool SetWindowText(
            IntPtr hWnd,
            string lpString);

        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint frequency, uint duration);

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(uint type);

        public const uint WM_CLOSE = 0x0010;
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MINIMIZE = 0xF020;
    }
}
