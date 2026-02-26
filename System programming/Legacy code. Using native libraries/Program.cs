using System.Runtime.InteropServices;

namespace WinApiHomework
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1 - Task 1 (Information about me)");
                Console.WriteLine("2 - Task 2 (Control window)");
                Console.WriteLine("3 - Task 3 (Beep sounds)");
                Console.WriteLine("4 - Task 4 (Change control text)");
                Console.WriteLine("5 - Exit");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void Task1()
        {
            NativeMethods.MessageBox(IntPtr.Zero, "Name: Geralt Roger", "Info", 0);
            NativeMethods.MessageBox(IntPtr.Zero, "Age: 128", "Info", 0);
            NativeMethods.MessageBox(IntPtr.Zero, "Student of IT STEP", "Info", 0);
        }

        static void Task2()
        {
            Console.Write("Enter window title to find: ");
            string title = Console.ReadLine();

            IntPtr window = NativeMethods.FindWindow(null, title);

            if (window == IntPtr.Zero)
            {
                Console.WriteLine("Window not found.");
                return;
            }

            Console.WriteLine("1 - Change title");
            Console.WriteLine("2 - Close window");
            Console.WriteLine("3 - Minimize window");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter new title: ");
                    string newTitle = Console.ReadLine();
                    NativeMethods.SetWindowText(window, newTitle);
                    break;

                case 2:
                    NativeMethods.SendMessage(window,
                        NativeMethods.WM_CLOSE,
                        IntPtr.Zero,
                        IntPtr.Zero);
                    break;

                case 3:
                    NativeMethods.SendMessage(window,
                        NativeMethods.WM_SYSCOMMAND,
                        (IntPtr)NativeMethods.SC_MINIMIZE,
                        IntPtr.Zero);
                    break;
            }
        }

        static void Task3()
        {
            for (int i = 0; i < 5; i++)
            {
                NativeMethods.Beep(800, 300);
                Thread.Sleep(500);
                NativeMethods.Beep(1000, 300);
                Thread.Sleep(500);
            }

            NativeMethods.MessageBeep(0);
        }

        static void Task4()
        {
            Console.Write("Enter window title (StyledApp): ");
            string title = Console.ReadLine();

            IntPtr mainWindow = NativeMethods.FindWindow(null, title);

            if (mainWindow == IntPtr.Zero)
            {
                Console.WriteLine("Window not found.");
                return;
            }

            IntPtr textBox = NativeMethods.FindWindowEx(
                mainWindow,
                IntPtr.Zero,
                "Edit",
                null);

            if (textBox != IntPtr.Zero)
            {
                IntPtr textPtr = Marshal.StringToHGlobalUni("Text changed externally");

                NativeMethods.SendMessage(
                    textBox,
                    NativeMethods.WM_SETTEXT,
                    IntPtr.Zero,
                    textPtr);

                Marshal.FreeHGlobal(textPtr);

                Console.WriteLine("TextBox text changed.");
            }
            else
            {
                Console.WriteLine("TextBox not found.");
            }
        }
    }
}
