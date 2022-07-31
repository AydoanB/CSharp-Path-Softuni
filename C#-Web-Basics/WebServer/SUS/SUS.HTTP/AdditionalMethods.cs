using System.Text;

namespace SUS.HTTP;

public static class AdditionalMethods
{
    public static byte[] RequestEncoder(string text)
    {
        var responseToByte = Encoding.UTF8.GetBytes(text);

        return responseToByte;
    }
}