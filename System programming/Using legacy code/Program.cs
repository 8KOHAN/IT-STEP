namespace IT_STEP
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("MENU:");
                Console.WriteLine("1 - Show Hello World (Task 1)");
                Console.WriteLine("2 - Play Guessing Game (Task 2)");
                Console.WriteLine("3 - Close Notepad (Task 3)");
                Console.WriteLine("4 - Show Time in Notepad Title (Task 4)");
                Console.WriteLine("5 - Exit");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                switch (choice)
                {
                    case 1:
                        NativeMethods.MessageBoxA(
                            IntPtr.Zero,
                            "Hello, World!",
                            "Task 1",
                            0);
                        break;

                    case 2:
                        PlayGame();
                        break;

                    case 3:
                        CloseNotepad();
                        break;

                    case 4:
                        UpdateNotepadTitle();
                        break;

                    case 5:
                        return;
                }
            }
        }

        static void PlayGame()
        {
            while (true)
            {
                NativeMethods.MessageBoxA(
                    IntPtr.Zero,
                    "Think of a number between 0 and 100 and press OK.",
                    "Guessing Game",
                    0);

                int min = 0;
                int max = 100;
                int guess;

                while (true)
                {
                    guess = (min + max) / 2;

                    Console.WriteLine($"Is your number {guess}?");
                    Console.WriteLine("Enter '>' if your number is greater.");
                    Console.WriteLine("Enter '<' if your number is smaller.");
                    Console.WriteLine("Enter '=' if correct.");

                    string input = Console.ReadLine();

                    if (input == "=")
                    {
                        NativeMethods.MessageBoxA(
                            IntPtr.Zero,
                            "I guessed your number!",
                            "Success",
                            0);
                        break;
                    }
                    else if (input == ">")
                    {
                        min = guess + 1;
                    }
                    else if (input == "<")
                    {
                        max = guess - 1;
                    }

                    if (min > max)
                    {
                        Console.WriteLine("Invalid input detected.");
                        break;
                    }
                }

                Console.WriteLine("Play again? (y/n)");
                string again = Console.ReadLine();
                if (again?.ToLower() != "y")
                    break;
            }
        }

        static void CloseNotepad()
        {
            IntPtr notepad = NativeMethods.FindWindow("Notepad", null);

            if (notepad != IntPtr.Zero)
            {
                NativeMethods.SendMessage(
                    notepad,
                    0x0010,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
            else
            {
                NativeMethods.MessageBoxA(
                    IntPtr.Zero,
                    "Notepad was not found.",
                    "Error",
                    16);
            }
        }

        static void UpdateNotepadTitle()
        {
            IntPtr notepad = NativeMethods.FindWindow("Notepad", null);

            if (notepad == IntPtr.Zero)
            {
                NativeMethods.MessageBoxA(
                    IntPtr.Zero,
                    "Notepad was not found.",
                    "Error",
                    16);
                return;
            }

            Console.WriteLine("Updating Notepad title. Press Ctrl+C to stop.");

            while (true)
            {
                string time = DateTime.Now.ToString("HH:mm:ss");

                NativeMethods.SetWindowText(
                    notepad,
                    $"Current time: {time}");

                Thread.Sleep(1000);
            }
        }
    }
}
