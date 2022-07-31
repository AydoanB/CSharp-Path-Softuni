using System;
using System.Text;
using System.Threading.Tasks;
using SUS.HTTP;

namespace MyFirstMvcApps
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer();
            server.AddRoute("/", HomePage);
            server.AddRoute("/AboutUs", AboutUs);
            await server.StartAsync(80);
        }

        static HttpResponse HomePage(HttpRequest request)
        {
            var responseBody = $@"<h1>Welcome</h1>
                            <p>To my site</p>";

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseBody);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        static HttpResponse AboutUs(HttpRequest request)
        {
            var responseBody = $@"<h1>About Us</h1>
                            <p>Wait</p>";

            var responseBytes = request.RequestEncoder(responseBody);
            var response = new HttpResponse("text/html", responseBytes);

            return response;
        }
    }
}
