using System.Runtime.InteropServices;

namespace IT_STEP
{
    public static class NativeMethods
    {
        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int MessageBoxA(
            IntPtr hWnd,
            string lpText,
            string lpCaption,
            uint uType);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(
            string lpClassName,
            string lpWindowName);

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
    }
}
