using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Model.Queries;
using Domain.SpeedyRent.Repositories;
using Domain.SpeedyRent.Services;

namespace Application.SpeedyRent.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;

    public UserQueryService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await _userRepository.FindByIdAsync(query.Id);
    }
}