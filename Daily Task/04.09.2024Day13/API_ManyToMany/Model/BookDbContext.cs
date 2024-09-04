using Microsoft.EntityFrameworkCore;
using API_ManyToMany.Model;

namespace API_ManyToMany.Model
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.book)
                .WithMany(a => a.bookAuthor)
                .HasForeignKey(a => a.BookId);

            modelBuilder.Entity<BookAuthor>()
               .HasOne(ba => ba.author)
               .WithMany(a => a.bookAuthor)
               .HasForeignKey(a => a.AuthorId);
        }
        public DbSet<API_ManyToMany.Model.Book> Book { get; set; } = default!;
        public DbSet<API_ManyToMany.Model.Author> Author { get; set; } = default!;
        public DbSet<API_ManyToMany.Model.BookAuthor> BookAuthor { get; set; } = default!;
    }
}
