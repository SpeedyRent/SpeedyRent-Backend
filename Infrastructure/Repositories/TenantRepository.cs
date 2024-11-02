using Login_back.Domain.Model;
using Login_back.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class TenantRepository : IBaseRepository<Tenant>
    {
        private readonly ApplicationDbContext _context;

        public TenantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            return await _context.Tenants.FindAsync(id);
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task AddAsync(Tenant entity)
        {
            await _context.Tenants.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Tenant entity)
        {
            _context.Tenants.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Tenant entity)
        {
            _context.Tenants.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}