using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly CommitsService CommitsService;
        private readonly RepositoryService RepositoryService;

        public CommitsController(CommitsService service, RepositoryService repositoryService)
        {
            this.CommitsService = service;
            this.RepositoryService = repositoryService;
        }


        public HttpResponse All()
        {
            return this.View();
        }


        public HttpResponse Create(string id)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();


            var viewModel = this.RepositoryService.GetRepositoryById(id);


            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateCommitInputModel model)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();

            this.CommitsService.Create(model.Description, model.Id, userId);

            return this.Redirect();
        }


    }
}