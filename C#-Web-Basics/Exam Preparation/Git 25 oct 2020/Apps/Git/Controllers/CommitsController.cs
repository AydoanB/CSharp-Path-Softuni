using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        [HttpGet("/Commits/All")]
        public HttpResponse All()
        {
            return this.View();
        }

        [HttpGet("/Commits/Create")]
        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        

    }
}