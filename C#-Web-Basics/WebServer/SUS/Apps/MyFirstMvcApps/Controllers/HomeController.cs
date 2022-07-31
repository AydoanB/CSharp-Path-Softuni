

using SUS.HTTP;

public class HomeController : Controller
{

    public HttpResponse Index(HttpRequest request)
    {
        return View();
    }

    public HttpResponse AboutUs(HttpRequest request)
    {
        return View();
    }
}