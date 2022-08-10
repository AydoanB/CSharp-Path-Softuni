using System;
using Git.Data;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext context;

        public CommitsService(ApplicationDbContext db)
        {
            this.context = db;
        }

        public void Create
            (string description, string repositoryId, string creatorId)
        {
            var commit = new Commit()
            {
                RepositoryId = repositoryId,
                CreatedOn = DateTime.Now,
                CreatorId = creatorId,
                Description = description,
            };
            
            this.context.Commits.Add(commit);
            this.context.SaveChanges();

        }
    }
}