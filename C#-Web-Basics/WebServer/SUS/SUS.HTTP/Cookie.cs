using System;

namespace SUS.HTTP;

public class Cookie
{
    public Cookie(string name,string value)
    {
        this.Name = name;
        this.Value = value;
    }
    public Cookie(string cookieLine)
    {
        var cookieParts = cookieLine.Split('=', 2);
        this.Name = cookieParts[0];
        this.Value = cookieParts[1];

    }

    public string Name { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return $"{Name}={Value}";
    }
}