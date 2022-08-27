using WebApi_Library.Data;
using WebApi_Library.Repositories.Interfaces;

namespace WebApi_Library.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork (DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task commitAsync()
        {
            await _context.SaveChangesAsync();
        }
        private IClientRepository _clientRepository;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IRequestRepository _requestRepository;
        public IRequestRepository requestRepository 
        {
            get { return _requestRepository ??= new RequestRepository(_context); }
        }

        public IClientRepository clientRepository
        {
            get { return _clientRepository ??= new ClientRepository(_context); }
        }

        public IBookRepository bookRepository 
        {
            get { return _bookRepository ??= new BookRepository(_context); }
        }

        public IAuthorRepository authorRepository
        {
            get { return _authorRepository ??= new AuthorRepository(_context); }
        }
    }
}
