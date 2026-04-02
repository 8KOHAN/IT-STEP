using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Program
    {
        private const int PORT = 5001;

        private static string connectionString =
    @"Server=ALEKSEY\IT_STEP;
            Database=ChatDb;
            Trusted_Connection=True;
            TrustServerCertificate=True;";

        static async Task Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(new IPEndPoint(IPAddress.Any, PORT));
            server.Listen(10);

            Console.WriteLine($"Server started on {PORT}");

            while (true)
            {
                Socket client = await server.AcceptAsync();
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private static async Task HandleClientAsync(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int received = await client.ReceiveAsync(buffer);
                    if (received == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, received);

                    if (msg.StartsWith("REG:"))
                    {
                        var parts = msg.Split(':');
                        string username = parts[1];
                        string password = parts[2];

                        string result = Register(username, password);

                        await client.SendAsync(Encoding.UTF8.GetBytes(result));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private static string Register(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@username";
                    using (SqlCommand cmd = new SqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                            return "ERROR: Username already exists";
                    }

                    string insertQuery =
                        "INSERT INTO Users (Username, Password) VALUES (@username, @password)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        cmd.ExecuteNonQuery();
                    }
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
    }
}
