using Domain.Shared;
using Domain.SpeedyRent.Model.Entities;

namespace Domain.SpeedyRent.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
}