
using SUS.HTTP;

public class StaticFilesController : Controller
{
   public HttpResponse Favicon(HttpRequest request)
   {
       return ImageView("wwwroot/favicon.ico");
   }
}