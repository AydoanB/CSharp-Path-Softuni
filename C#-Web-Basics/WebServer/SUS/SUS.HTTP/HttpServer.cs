using SUS.HTTP.Enum;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HttpStatusCode = SUS.HTTP.Enum.HttpStatusCode;

namespace SUS.HTTP;

public class HttpServer : IHttpServer
{
    private List<Route> routeTable;

    public HttpServer(List<Route> routeTable)
    {
        this.routeTable= routeTable;
    }

    

    public async Task StartAsync(int port)
    {
        ///<summary>Starts new listener who is ready to accept request</summary>
        TcpListener listener = new TcpListener(IPAddress.Loopback, port);

        listener.Start();
        while (true)
        {
            /// <summary>Kepps connection with the tcpClient</summary>
            TcpClient client = await listener.AcceptTcpClientAsync();

            ProcessClientAsync(client);
        }
    }

    private async Task ProcessClientAsync(TcpClient tcpClient)
    {
        try
        {
            using NetworkStream stream = tcpClient.GetStream();

            byte[] buffer = new byte[4096];

            List<byte> data = new List<byte>();
            int position = 0;

            while (true)
            {
                int count = await stream.ReadAsync(buffer, position, buffer.Length);
                position += count;
                if (count < buffer.Length)
                {
                    var partialBuffer = new byte[count];

                    Array.Copy(buffer, partialBuffer, count);

                    data.AddRange(partialBuffer);

                    ///<summary>There we break because there are no data in the buffer anymore
                    /// buffer is not full</summary>
                    break;
                }
                else
                {
                    data.AddRange(buffer);
                }
            }
            var parsedRequest = Encoding.UTF8.GetString(data.ToArray());

            var request = new HttpRequest(parsedRequest);
            Console.WriteLine(parsedRequest);



            ///<summary>Generate dynamic view</summary>
            HttpResponse response;
            var route = this.routeTable.FirstOrDefault(x => x.Path == request.Path);
            if (route!=null)
            {
                response = route.Action(request);
            }
            else
            {
                response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
            }


            response.Cookies.Add(new ResponseCookie("sid",Guid.NewGuid().ToString()));
            response.Cookies.Add(new ResponseCookie("Server","SUS Server 1.0"));
            var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
            await stream.WriteAsync(responseHeaderBytes);
            await stream.WriteAsync(response.Body);

            tcpClient.Close();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }


}