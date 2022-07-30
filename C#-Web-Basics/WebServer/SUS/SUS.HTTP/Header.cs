using System;

namespace SUS.HTTP;

public class Header
{
    public Header(string name,string value)
    {
        this.Name=name;
        this.Value=value;
    }
    public Header(string headerLine)
    {
        string[] SplittedHeaderName = headerLine.Split(": ",2,StringSplitOptions.None);

        this.Name = SplittedHeaderName[0];
        this.Value = SplittedHeaderName[1];
    }

    public string Name { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{Name}: {Value}";
    }
}