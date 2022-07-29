using System;
using System.Threading.Tasks;
using SUS.HTTP;

namespace MyFirstMvcApps
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer(); 

            
           await server.StartAsync(80);

        }

        static HttpResponse HomePage(HttpRequest request)
        {
            return new HttpResponse();
        }
    }
}
