using Microsoft.EntityFrameworkCore;
using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var client = _context.Clients.SingleOrDefault(x => x.Id == id);
            _context.Clients.Remove(client);
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Client entity)
        {
            _context.Clients.Add(entity);
        }

        public void Update(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
