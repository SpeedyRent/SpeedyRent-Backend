using Domain.SpeedyRent.Model.Commands;

namespace Domain.SpeedyRent.Services;

public interface IPostCommandService
{
    Task<int> Handle(CreatePostCommand command);
    Task<bool> Handle(UpdatePostCommand command);
    Task<bool> Handle(DeletePostCommand command);
}