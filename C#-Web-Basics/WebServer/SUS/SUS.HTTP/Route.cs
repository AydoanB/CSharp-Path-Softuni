using System;
using SUS.HTTP.Enum;

namespace SUS.HTTP;

public class Route
{
    public Route(string path,Func<HttpRequest,HttpResponse> action,HttpMethod method=HttpMethod.GET)
    {
        this.Path=path;
        this.Action = action;
        this.HttpMethod=method;
    }

    public string Path { get; set; }
    public Func<HttpRequest,HttpResponse> Action { get; set; }
    public HttpMethod HttpMethod { get; set; }
}