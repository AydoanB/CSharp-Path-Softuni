using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.HTTP;

public class HttpResponse
{
    public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
    {
        if (body == null)
        {
            throw new ArgumentException("Body cannot be null");
        }
        this.Body = body;
        this.StatusCode = statusCode;
        this.Headers = new List<Header>()
        {
            {new Header("Content-Type",contentType)},
            {new Header("Content-Length",body.Length.ToString())},
            {new Header("Server","SUS Server 1.0")},
        };

        this.Cookies = new List<ResponseCookie>();
    }
    public ICollection<Header> Headers { get; set; }
    public ICollection<ResponseCookie> Cookies { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public byte[] Body { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"HTTP/1.1 {(int)StatusCode} {this.StatusCode}" + HttpConstants.NewLine);

        foreach (var header in Headers)
        {
            sb.Append(header.ToString() + HttpConstants.NewLine);
        }

        foreach (var cookie in this.Cookies)
        {
            sb.Append("Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
        }

        sb.Append(HttpConstants.NewLine);

        return sb.ToString();
    }
}