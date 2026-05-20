using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Contexts
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }

        public LibraryDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(b => b.BookId).HasName("pk_books"); // pk

                // not null
                b.Property(b => b.Title).IsRequired();
                b.Property(b => b.Author).IsRequired();

                // check constraints
                b.ToTable(b => b.HasCheckConstraint("ck_available_copies", "\"AvailableCopies\" >= 0"));
                b.ToTable(t => t.HasCheckConstraint("ck_publication_year", "\"PublicationYear\" >= 1000 AND \"PublicationYear\" <= 2026"));
            });

            modelBuilder.Entity<Member>(u =>
            {
                u.HasKey(u => u.MemberId).HasName("pk_members");

                u.HasIndex(u => u.Phone).IsUnique();
                u.HasIndex(u => u.Email).IsUnique();

                u.Property(u => u.MemberName).IsRequired();
                u.Property(u => u.Email).IsRequired();
                u.Property(u => u.Phone).IsRequired();

                u.Property(u => u.MembershipDate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<Book>().ToTable("books");
            modelBuilder.Entity<Member>().ToTable("members");
        }
    }
}
