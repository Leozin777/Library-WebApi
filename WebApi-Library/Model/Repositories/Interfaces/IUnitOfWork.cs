namespace WebApi_Library.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task commitAsync();

        IClientRepository clientRepository { get; }
        IBookRepository bookRepository { get; }
        IAuthorRepository authorRepository { get; }
        IRequestRepository requestRepository { get; }
    }
}
