using Login_back.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class TenantRepository
    {
        private readonly ApplicationDbContext _context;

        public TenantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
        }

        public async Task<Tenant?> GetByUserIdAsync(string userId)
        {
            return await _context.Tenants.FirstOrDefaultAsync(t => t.TenantUserId == userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}