using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Model.Queries;
using Domain.SpeedyRent.Repositories;
using Domain.SpeedyRent.Services;

namespace Application.SpeedyRent.QueryServices;

public class PostQueryService : IPostQueryService
{
    private readonly IPostRepository _postRepository;

    public PostQueryService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery query)
    {
        return await _postRepository.ListAsync();
    }

    public async Task<Post?> Handle(GetPostByIdQuery query)
    {
        return await _postRepository.FindByIdAsync(query.Id);
    }
}