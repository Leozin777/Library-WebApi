using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_Library.Model.Entities;

namespace WebApi_Library.Data.Types
{
    public class RequestMap : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("requests");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.HasOne(x => x.Client)
                .WithMany(x => x.Requests)
                .HasConstraintName("FK_Requests_Client")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.)
                .HasConstraintName("FK_Requests_Book")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
