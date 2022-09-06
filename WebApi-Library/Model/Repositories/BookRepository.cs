using Microsoft.EntityFrameworkCore;
using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book == null)
                return false;
            else
            {
                _context.Books.Remove(book);
                return true;
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
        }

        public void Save(Book entity)
        {
            _context.Add(entity);
        }

        public void Update(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
