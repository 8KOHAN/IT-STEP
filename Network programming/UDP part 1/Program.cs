using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleUDPChat
{
    public class Program
    {
        static int _remotePort;
        static IPAddress _remoteIp = null!;
        static int _localPort;

        static string _username = "";
        static ConsoleColor _userColor;

        static object lockObj = new object();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Chat";

            Console.Write("Enter username: ");
            _username = Console.ReadLine() ?? "User";

            Console.WriteLine("Choose color:");
            foreach (var color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.WriteLine(color);
            }

            _userColor = Enum.Parse<ConsoleColor>(Console.ReadLine(), true);

            Console.Write("Enter remote IP: ");
            _remoteIp = IPAddress.Parse(Console.ReadLine() ?? "127.0.0.1");

            Console.Write("Enter remote port: ");
            _remotePort = int.Parse(Console.ReadLine());

            Console.Write("Enter local port: ");
            _localPort = int.Parse(Console.ReadLine());

            _ = Task.Run(ReceiveData);

            Console.ForegroundColor = ConsoleColor.Red;

            while (true)
            {
                SendData(Console.ReadLine());
            }
        }

        private static void SendData(string? data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            using UdpClient client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(_remoteIp, _remotePort);

            try
            {
                string fullMessage = $"{_username}|{_userColor}|{data}";
                byte[] buffer = Encoding.UTF8.GetBytes(fullMessage);

                client.Send(buffer, buffer.Length, ep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReceiveData()
        {
            using UdpClient client = new UdpClient(_localPort);

            try
            {
                while (true)
                {
                    IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 0);

                    byte[] buffer = client.Receive(ref ipEnd);
                    string msg = Encoding.UTF8.GetString(buffer);

                    string[] parts = msg.Split('|');

                    if (parts.Length == 3)
                    {
                        string username = parts[0];
                        ConsoleColor color = Enum.Parse<ConsoleColor>(parts[1]);
                        string text = parts[2];

                        lock (lockObj)
                        {
                            Console.ForegroundColor = color;
                            Console.WriteLine($"[{username}]: {text}");
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
