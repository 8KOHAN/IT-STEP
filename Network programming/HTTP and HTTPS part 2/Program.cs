using System.Net;
using System.Text;
using System.Text.Json;

namespace LocalHttpServer
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();

            Console.WriteLine("Server started at http://localhost:8080/");

            while (true)
            {
                var context = await listener.GetContextAsync();
                _ = Task.Run(() => HandleRequest(context));
            }
        }

        private static async Task HandleRequest(HttpListenerContext context)
        {
            string path = context.Request.Url.AbsolutePath;

            Console.WriteLine($"Request: {path}");

            string responseString = "";
            string contentType = "text/html";

            switch (path)
            {
                case "/":
                    responseString = GetHomePage();
                    break;

                case "/autobiography":
                    responseString = GetAutobiography();
                    break;

                case "/fav_countries":
                    responseString = GetCountries();
                    break;

                case "/pc_data":
                    contentType = "application/json";
                    responseString = GetPcData();
                    break;

                default:
                    context.Response.StatusCode = 404;
                    responseString = "<h1>404 - Not Found</h1>";
                    break;
            }

            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            context.Response.ContentType = contentType;
            context.Response.ContentLength64 = buffer.Length;

            await context.Response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            context.Response.Close();
        }

        private static string GetHomePage()
        {
            return @"
            <html>
            <body>
                <h1>Welcome!</h1>
                <ul>
                    <li><a href='/autobiography'>Autobiography</a></li>
                    <li><a href='/fav_countries'>Favorite Countries</a></li>
                    <li><a href='/pc_data'>PC Data (JSON)</a></li>
                </ul>
            </body>
            </html>";
        }

        private static string GetAutobiography()
        {
            return @"
            <html>
            <body>
                <h1>My Autobiography</h1>
                <p>I am a student</p>
                <p>I like programming and building applications.</p>
                <a href='/'>Back</a>
            </body>
            </html>";
        }

        private static string GetCountries()
        {
            return @"
            <html>
            <body>
                <h1>Favorite Countries</h1>
                <ul>
                    <li>Japan</li>
                    <li>Germany</li>
                    <li>Canada</li>
                </ul>
                <a href='/'>Back</a>
            </body>
            </html>";
        }

        private static string GetPcData()
        {
            var data = new
            {
                MachineName = Environment.MachineName,
                OS = Environment.OSVersion.ToString(),
                ProcessorCount = Environment.ProcessorCount,
                Is64Bit = Environment.Is64BitOperatingSystem,
                User = Environment.UserName
            };

            return JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
