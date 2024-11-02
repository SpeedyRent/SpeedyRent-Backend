using Domain.Shared;
using Domain.SpeedyRent.Model.Entities;

namespace Domain.SpeedyRent.Repositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<Post?> FindByTitleAsync(string title);
    }
}