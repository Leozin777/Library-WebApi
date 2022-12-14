// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi_Library.Data;

#nullable disable

namespace WebApi_Library.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220928203301_Relações")]
    partial class Relações
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi_Library.Model.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("description");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("genre");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<int>("RequestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("RequestId");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("phoneNumber");

                    b.HasKey("Id");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("requests", (string)null);
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Book", b =>
                {
                    b.HasOne("WebApi_Library.Model.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Books_Author");

                    b.HasOne("WebApi_Library.Model.Entities.Request", "Request")
                        .WithMany("Book")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Requests_Book");

                    b.Navigation("Author");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Request", b =>
                {
                    b.HasOne("WebApi_Library.Model.Entities.Client", "Client")
                        .WithMany("Requests")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Requests_Client");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Client", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("WebApi_Library.Model.Entities.Request", b =>
                {
                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}
