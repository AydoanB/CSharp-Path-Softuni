using System;
using System.Collections.Generic;

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

            this.Method = splittedHeaderLine[0];
            this.Path = splittedHeaderLine[1];

            int lineIndex = 1;
            bool IsInHeaders = true;
            while (lineIndex < SplittedRequest.Length)
            {
                var line = SplittedRequest[lineIndex++];

                if (IsInHeaders)
                {
                    this.Headers.Add(new Header(line));
                }
                else
                {
                    this.Body += line + HttpConstants.NewLine;
                }



                if (string.IsNullOrWhiteSpace(line))
                {
                    IsInHeaders = false;
                    break;
                }
            }
        }

        public string Path { get; set; }

        public string Method { get; set; }

        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }



    }
}
