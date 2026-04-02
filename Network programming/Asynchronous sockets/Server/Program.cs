using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Program
    {
        private const int PORT = 5001;

        private static List<Socket> clients = new();
        private static List<string> messages = new();

        static async Task Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, PORT));
            server.Listen(10);

            Console.WriteLine($"Server listening on port {PORT}");

            while (true)
            {
                Socket client = await server.AcceptAsync();
                clients.Add(client);

                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private static async Task HandleClientAsync(Socket client)
        {
            string username = "Unknown";

            try
            {
                byte[] buffer = new byte[1024];

                int received = await client.ReceiveAsync(buffer);
                username = Encoding.UTF8.GetString(buffer, 0, received);

                string joinMsg = $"{username} connect to chat";
                messages.Add(joinMsg);
                Console.WriteLine(joinMsg);

                while (true)
                {
                    received = await client.ReceiveAsync(buffer);
                    if (received == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, received);

                    if (msg == "GET")
                    {
                        string allMessages = string.Join(Environment.NewLine, messages);
                        await client.SendAsync(Encoding.UTF8.GetBytes(allMessages));
                    }
                    else if (msg.StartsWith("MSG:"))
                    {
                        string text = msg.Substring(4);
                        string fullMsg = $"[{username}]: {text}";
                        messages.Add(fullMsg);

                        Console.WriteLine(fullMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                clients.Remove(client);
                client.Close();

                string leaveMsg = $"{username} leaving chat";
                messages.Add(leaveMsg);

                Console.WriteLine(leaveMsg);
            }
        }
    }
}
