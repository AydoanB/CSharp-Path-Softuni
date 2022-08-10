using System.Linq;
using Git.BindingModels.Repositories;
using Git.Data;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly RepositoryService RepositoryService;
        private readonly ApplicationDbContext context;

        public RepositoriesController(RepositoryService repositoryService, ApplicationDbContext db)
        {
            this.RepositoryService = repositoryService;
            this.context = db;
        }

        public HttpResponse All()
        {
             var viewModel = this.RepositoryService.GetAll().ToList();
           
            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoriesBindingModel input)
        {
            var userId = this.GetUserId();

            bool isPublic = input.repositoryType == "Public";

            this.RepositoryService.CreateRepository(input.Name, isPublic, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}