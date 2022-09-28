using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_Library.Model.Entities;

namespace WebApi_Library.Data.Types
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i=> i.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Genre)
                .HasColumnName("genre")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasColumnName("description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasConstraintName("FK_Books_Author")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
