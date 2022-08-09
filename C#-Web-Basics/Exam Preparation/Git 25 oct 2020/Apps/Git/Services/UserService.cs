using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.BindingModels.Users;
using Git.Data;

namespace Git.Services
{
    public class UserService : IUserService
    {
        SHA512 sha512 = SHA512.Create();
        private static ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext db)
        {
            dbContext = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Id = new Guid().ToString(),
                Username = username,
                Password = password,
                Email = email,
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return dbContext.Users.Any(x => x.Email == email);
        }

        public string GetUserId(string username, string password)
        {
            //TODO Possible problem with hashed password

            var user = dbContext.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            return user?.Id;
        }

        public bool IsUsernameAvailable(string username)
        {
            return dbContext.Users.Any(x => x.Username == username);
        }
    }
}