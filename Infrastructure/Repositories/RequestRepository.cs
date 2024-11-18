using Login_back.Domain.Model;

namespace Login_back.Infrastructure.Repositories
{
    public class RequestRepository : BaseRepository<Request>
    {
        public RequestRepository(ApplicationDbContext context) : base(context) { }
    }
}