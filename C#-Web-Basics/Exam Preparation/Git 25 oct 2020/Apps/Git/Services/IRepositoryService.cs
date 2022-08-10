using System.Collections.Generic;
using Git.BindingModels.Repositories;
using Git.Data;
using Git.ViewModels;

namespace Git.Services
{
    public interface IRepositoryService
    {
        void CreateRepository(string name, bool isPublic, string userId);
        
        IEnumerable<RepositoryViewModel> GetAll();

        RepositoryViewModel GetRepositoryById(string id);

    }
}