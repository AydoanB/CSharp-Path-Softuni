namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string description, string repositoryId, string creatorId);
    }
}