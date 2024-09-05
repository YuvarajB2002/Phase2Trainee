using API_ManyToMany.Interface;
using API_ManyToMany.Model;
using Microsoft.EntityFrameworkCore;

namespace API_ManyToMany.Repository
{
    public class BookRepository : IBook
    {
        private readonly BookDbContext _context;
        public BookRepository(BookDbContext context)
        {
            _context= context;
        }
        public async Task AddBook(Book b)
        {
            await _context.Book.AddAsync(b);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int bid)
        {
            var b = await _context.Book.FindAsync(bid);
            if (b != null)
            {
                _context.Book.Remove(b);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.Book.Include(b => b.bookAuthor!)
                 .ThenInclude(a => a.author).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Book.Include(b => b.bookAuthor!)
                 .ThenInclude(a => a.author).FirstOrDefaultAsync(e => e.BookId == id) ?? throw new NullReferenceException();

        }

        public async Task UpdateBook(int id, Book b)
        {
            if (id == b.BookId)
            {
                _context.Entry(b).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
