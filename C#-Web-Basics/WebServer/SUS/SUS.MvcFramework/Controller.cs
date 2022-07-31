
using System;
using System.IO;
using System.Runtime.CompilerServices;
using SUS.HTTP;

public abstract class Controller
{
    public HttpResponse View([CallerMemberName] string path = null)
    {
        string folderName = this.GetType().Name.Replace("Controller", String.Empty);

        var layout = File.ReadAllText("Views/Shared/_Layout.cshtml");
        var file = File.ReadAllText("Views/" + folderName + "/" + path + ".cshtml");

        var responseBody = layout.Replace("@RenderBody()", file);
        layout.Replace("@ViewBag.Title", "Aydoanee");
        var responseBodyToBytes = AdditionalMethods.RequestEncoder(responseBody);

        return new HttpResponse("text/html", responseBodyToBytes);
    }

    public HttpResponse ImageView(string path)
    {
        var image = File.ReadAllBytes(path);
        return new HttpResponse("image/vnd.microsoft.icon", image);
    }
}