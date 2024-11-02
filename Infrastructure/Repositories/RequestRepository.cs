using Login_back.Domain.Model;
using Login_back.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Login_back.Infrastructure.Repositories
{
    public class RequestRepository : IBaseRepository<Request>
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<IEnumerable<Request>> GetAllAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task AddAsync(Request entity)
        {
            await _context.Requests.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Request entity)
        {
            _context.Requests.Update(entity);
            _context.SaveChangesAsync();
        }

        public void Delete(Request entity)
        {
            _context.Requests.Remove(entity);
            _context.SaveChangesAsync();
        }
    }
}