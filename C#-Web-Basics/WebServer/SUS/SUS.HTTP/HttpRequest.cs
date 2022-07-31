using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SUS.HTTP.Enum;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        private string[] SplittedRequest;
        public HttpRequest(string requestString)
        {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();

            SplittedRequest = requestString.Split(new string[] { HttpConstants.NewLine }, StringSplitOptions.None);

            var headerLine = SplittedRequest[0];
            var splittedHeaderLine = headerLine.Split(" ");

            this.Method = (HttpMethod)System.Enum.Parse(typeof(HttpMethod), splittedHeaderLine[0], true);
            this.Path = splittedHeaderLine[1];

            int lineIndex = 1;
            bool IsInHeaders = true;

            StringBuilder bodyBuilder = new StringBuilder();

            while (lineIndex < SplittedRequest.Length)
            {
                var line = SplittedRequest[lineIndex++];

                if (string.IsNullOrWhiteSpace(line))
                {
                    IsInHeaders = false;
                }

                if (IsInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }


            }
            this.Body = bodyBuilder.ToString();

            var cookieHeader = this.Headers.Any(x => x.Name == "Cookie");
            if (cookieHeader)
            {
                var cookieLine = this.Headers.FirstOrDefault(x => x.Name == "Cookie").Value;
                var CookiesSplitted = cookieLine.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var Cookie in CookiesSplitted)
                {
                    this.Cookies.Add(new Cookie(Cookie));
                }
            }

        }

        

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }



    }
}
