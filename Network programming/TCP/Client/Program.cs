using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Program
    {
        private const int PORT = 5002;

        static async Task Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            await client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, PORT));

            Console.WriteLine("Connected to server.");
            Console.WriteLine("Press ENTER to get quote, type 'exit' to quit.");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    await client.SendAsync(Encoding.UTF8.GetBytes("EXIT"));
                    break;
                }

                await client.SendAsync(Encoding.UTF8.GetBytes("GET"));

                byte[] buffer = new byte[1024];
                int received = await client.ReceiveAsync(buffer);

                string quote = Encoding.UTF8.GetString(buffer, 0, received);

                Console.WriteLine($"Quote: {quote}");
            }

            client.Close();
            Console.WriteLine("Disconnected.");
        }
    }
}
