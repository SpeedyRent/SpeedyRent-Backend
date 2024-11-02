using Login_back.Domain.Model;
using Login_back.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class OwnerRepository : IBaseRepository<Owner>
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task AddAsync(Owner entity)
        {
            await _context.Owners.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Owner entity)
        {
            _context.Owners.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Owner entity)
        {
            _context.Owners.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}