using Login_back.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class OwnerRepository
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task<Owner?> GetByUserIdAsync(string userId)
        {
            return await _context.Owners.FirstOrDefaultAsync(o => o.OwnerUserId == userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}