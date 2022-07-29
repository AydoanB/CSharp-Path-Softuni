using System;

namespace SUS.HTTP;

public class Cookie
{
    private string[] SplittedHeaderName;
    public Cookie(string headerLine)
    {
        SplittedHeaderName = headerLine.Split(": ", 2, StringSplitOptions.None);

        this.Name = SplittedHeaderName[0];
        this.Value = SplittedHeaderName[1];

    }

    public string Name { get; set; }
    public string Value { get; set; }
}