using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Model.Queries;

namespace Domain.SpeedyRent.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
}