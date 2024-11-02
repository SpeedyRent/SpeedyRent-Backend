using Domain.Shared;
using Domain.SpeedyRent.Model.Commands;
using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Repositories;
using Domain.SpeedyRent.Services;

namespace Application.SpeedyRent.CommandServices;

public class PostCommandService : IPostCommandService
{
    private readonly IPostRepository _postRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PostCommandService(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreatePostCommand command)
    {
        var post = new Post
        {
            Title = command.Title,
            Content = command.Content,
            UserId = command.AuthorId
        };

        await _postRepository.AddAsync(post);
        await _unitOfWork.CompleteAsync();
        return post.Id;
    }

    public async Task<bool> Handle(UpdatePostCommand command)
    {
        var existingPost = await _postRepository.FindByIdAsync(command.Id);
        if (existingPost == null) return false;

        existingPost.Title = command.Title;
        existingPost.Content = command.Content;

        await _postRepository.UpdateAsync(existingPost);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    public async Task<bool> Handle(DeletePostCommand command)
    {
        var post = await _postRepository.FindByIdAsync(command.Id);
        if (post == null) return false;

        await _postRepository.RemoveAsync(post);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}