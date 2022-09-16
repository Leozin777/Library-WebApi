﻿using Microsoft.EntityFrameworkCore;
using WebApi_Library.Data.Types;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new RequestMap());
        }
    }
}
