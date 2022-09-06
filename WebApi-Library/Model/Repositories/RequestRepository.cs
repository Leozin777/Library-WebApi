using Microsoft.EntityFrameworkCore;
using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;
        public RequestRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int id)
        {
            var request = _context.Requests.SingleOrDefault(x => x.Id == id);

            if (request == null)
                return false;
            else
            {
                _context.Requests.Remove(request);
                return true;
            }
        }

        public async Task<List<Request>> GetAllAsync()
        {
            return await _context.Requests.ToListAsync(); 
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Requests.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Request entity)
        {
            _context.Requests.Add(entity);
        }

        public void Update(Request entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
