using Domain.SpeedyRent.Model.Entities;
using Domain.SpeedyRent.Repositories;
using Infraestructure.Shared.Persistence.EFC.Configuration;
using Infrastructure.Shared.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.SpeedyRent;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Post?> FindByTitleAsync(string title)
    {
        return await Context.Set<Post>().FirstOrDefaultAsync(p => p.Title == title);
    }
}