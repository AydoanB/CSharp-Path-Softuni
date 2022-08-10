using System.Security.Cryptography;
using Git.BindingModels.Users;
using Git.Data;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService user)
        {
            this.userService = user;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            this.SignOut();
            return this.Redirect("/");
        }

        [HttpPost]
        public HttpResponse Register(UserRegisterBindingModel model)
        {
            //TODO Check for email and username availability and hash password
            if (model.Password != model.ConfirmPassword || !this.userService.IsEmailAvailable(model.Email) || !this.userService.IsUsernameAvailable(model.Username))
            {
                this.Redirect("/Users/Register");
            }

            var hashedPass = PasswordConverter.HashComute.HashConvert(model.Password);



            var id = this.userService.CreateUser(model.Username, model.Email, hashedPass);

            this.SignIn(id);

            return this.Redirect("/Users/Login");
        }

        [HttpPost]
        public HttpResponse Login(UsersLoginBindingModel model)
        {
            var hashedPass = PasswordConverter.HashComute.HashConvert(model.Password);

            var user = this.userService.GetUserId(model.Username, hashedPass);

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user);

            return this.Redirect("/");
        }
    }
}