using WebApi_Library.Data;
using WebApi_Library.Model.Entities;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private DataContext context;

        public BookRepository(DataContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
