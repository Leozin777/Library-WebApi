using Microsoft.EntityFrameworkCore;
using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == id);

            if (author == null)
                return false;
            else
            {
                _context.Authors.Remove(author);
                return true;
            }
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Author entity)
        {
            _context.Authors.Add(entity);
        }

        public void Update(Author entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
