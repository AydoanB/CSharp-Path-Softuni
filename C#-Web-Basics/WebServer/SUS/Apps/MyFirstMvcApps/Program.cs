using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using SUS.HTTP;

namespace MyFirstMvcApps
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var list = new List<Route>();
            list.Add(new Route("/", new HomeController().Index));
            list.Add(new Route("/AboutUs", new HomeController().AboutUs));
            list.Add(new Route("/Login", new UsersController().Login));
            list.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));

            var server = new HttpServer(list);


            Process.Start(@"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe", "http://localhost");
            await server.StartAsync(80);
        }

    }
}
