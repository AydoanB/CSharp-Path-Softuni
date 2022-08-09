using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        [HttpGet("/Repositories/All")]
        public HttpResponse All()
        {
            //if (!IsUserSignedIn())
            //{
            //    return this.Redirect("/Users/Login");
            //}
            return this.View();
        }

        
        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Repositories/Create")]
        public HttpResponse CreateRepo()
        {
            return this.View();
        }
    }
}