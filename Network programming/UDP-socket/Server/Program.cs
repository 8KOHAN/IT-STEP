using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        private const int PORT = 5001;
        static async Task Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            server.Bind(new IPEndPoint(IPAddress.Loopback, PORT));

            Console.WriteLine($"Server is running. Port: {PORT}");

            byte[] buffer = new byte[1024];
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

            Random rand = new Random();

            int randNum = rand.Next(0, 100);
            Console.WriteLine(randNum);

            HashSet<EndPoint> players = new HashSet<EndPoint>();

            while (true)
            {
                SocketReceiveFromResult received = await server.ReceiveFromAsync(buffer, SocketFlags.None, clientEP);

                EndPoint actualClientEP = received.RemoteEndPoint;
                players.Add(actualClientEP);

                int request = 0;
                try
                {
                    request = Convert.ToInt32(Encoding.UTF8.GetString(buffer, 0, received.ReceivedBytes));
                }
                catch (FormatException) 
                {
                    await server.SendToAsync(Encoding.UTF8.GetBytes("write number"), actualClientEP);
                    Console.WriteLine($"user {actualClientEP} enter not number");
                    continue;
                }
                


                byte[] reply = null!;
                if (request == randNum)
                {
                    reply = Encoding.UTF8.GetBytes($"User {actualClientEP} win, random number = {randNum}");

                    foreach (var player in players)
                    {
                        await server.SendToAsync(reply, SocketFlags.None, player);
                    }

                    Console.WriteLine($"User {actualClientEP} win, random number = {randNum}");
                    break;
                }
                else if (request >= randNum)
                {
                    reply = Encoding.UTF8.GetBytes($"Less");
                    Console.WriteLine($"user {actualClientEP} enter less number");
                }
                else if (request <= randNum)
                {
                    reply = Encoding.UTF8.GetBytes($"More");
                    Console.WriteLine($"user {actualClientEP} enter more number");
                }
                await server.SendToAsync(reply, actualClientEP);
            }
        }
    }
}
