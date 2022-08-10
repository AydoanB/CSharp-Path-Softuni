using System;
using System.Collections.Generic;
using System.Linq;
using Git.BindingModels.Repositories;
using Git.Data;
using Git.ViewModels;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }

        public void CreateRepository(string name, bool isPublic, string userId)
        {
            var repo = new Repository()
            {
                Name = name,
                IsPublic = isPublic,
                OwnerId = userId,
                CreatedOn = DateTime.Now.ToUniversalTime()
            };
            dbContext.Repositories.Add(repo);
            dbContext.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            return this.dbContext.Repositories
                .Select(x => new RepositoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CommitsCount = x.Commits.Count,
                    Owner = x.Owner.Username,
                    CreatedOn = x.CreatedOn,
                    IsPublic = x.IsPublic == true ? "Public" : "Private"
                }).ToList();
        }

        public RepositoryViewModel GetRepositoryById(string id)
        {
            return this.dbContext.Repositories.Where(x => x.Id == id)
                .Select(x => new RepositoryViewModel()
                {
                    Id = id,
                    Name = x.Name
                }).FirstOrDefault();
        }
    }
}