using Login_back.Domain.Model;
using Login_back.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class VehicleRepository : IBaseRepository<Vehicle>
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task AddAsync(Vehicle entity)
        {
            await _context.Vehicles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Vehicle entity)
        {
            _context.Vehicles.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Vehicle entity)
        {
            _context.Vehicles.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}