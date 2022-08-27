using Microsoft.EntityFrameworkCore;
using WebApi_Library.Model.Entities;

namespace WebApi_Library.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
