using Domain.Shared;
using Domain.SpeedyRent.Model.Commands;
using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Repositories;
using Domain.SpeedyRent.Services;

namespace Application.SpeedyRent.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateUserCommand command)
    {
        var user = new User
        {
            Username = command.Username,
            Email = command.Email,
            Password = command.Password // Asegúrate de manejar la contraseña adecuadamente
        };

        await _userRepository.AddAsync(user);
        await _unitOfWork.CompleteAsync();

        return user.Id;
    }

    public async Task<bool> Handle(UpdateUserCommand command)
    {
        var user = await _userRepository.FindByIdAsync(command.Id);
        if (user == null) return false;

        user.Username = command.Username;
        user.Email = command.Email;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> Handle(DeleteUserCommand command)
    {
        var user = await _userRepository.FindByIdAsync(command.Id);
        if (user == null) return false;

        await _userRepository.RemoveAsync(user);
        await _unitOfWork.CompleteAsync();
        return true;
    }
}