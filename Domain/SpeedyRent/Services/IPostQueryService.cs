using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Model.Queries;

namespace Domain.SpeedyRent.Services;

public interface IPostQueryService
{
    Task<IEnumerable<Post>> Handle(GetAllPostsQuery query);
    Task<Post?> Handle(GetPostByIdQuery query);
}