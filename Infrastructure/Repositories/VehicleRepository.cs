using Login_back.Domain.Model;

namespace Login_back.Infrastructure.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        public VehicleRepository(ApplicationDbContext context) : base(context) { }
    }
}