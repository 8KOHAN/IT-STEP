using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Program
    {
        private const int PORT = 5002;

        private static List<string> quotes = new()
        {
            "Stay hungry, stay foolish.",
            "To be or not to be.",
            "Knowledge is power.",
            "The only limit is your mind.",
            "Simplicity is the ultimate sophistication."
        };

        static async Task Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, PORT));
            server.Listen(100);

            Console.WriteLine($"Quote Server started on port {PORT}");

            while (true)
            {
                Socket client = await server.AcceptAsync();
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private static async Task HandleClientAsync(Socket client)
        {
            string clientInfo = client.RemoteEndPoint.ToString();

            Console.WriteLine($"[{DateTime.Now}] CONNECT: {clientInfo}");

            try
            {
                byte[] buffer = new byte[1024];
                Random rnd = new Random();

                while (true)
                {
                    int received = await client.ReceiveAsync(buffer);
                    if (received == 0) break;

                    string request = Encoding.UTF8.GetString(buffer, 0, received).Trim();

                    if (request == "GET")
                    {
                        string quote = quotes[rnd.Next(quotes.Count)];

                        Console.WriteLine($"[{DateTime.Now}] REQUEST from {clientInfo}");
                        Console.WriteLine($"[{DateTime.Now}] SENT: {quote}");

                        await client.SendAsync(Encoding.UTF8.GetBytes(quote));
                    }
                    else if (request == "EXIT")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"[{DateTime.Now}] DISCONNECT: {clientInfo}");
                client.Close();
            }
        }
    }
}
