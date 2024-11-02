using Domain.SpeedyRent.Model.Commands;

namespace Domain.SpeedyRent.Services;

public interface IUserCommandService
{
    Task<int> Handle(CreateUserCommand command);
    Task<bool> Handle(UpdateUserCommand command);
    Task<bool> Handle(DeleteUserCommand command);
}