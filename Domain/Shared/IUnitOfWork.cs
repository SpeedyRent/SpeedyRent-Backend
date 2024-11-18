namespace Login_back. Domain. Shared
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}