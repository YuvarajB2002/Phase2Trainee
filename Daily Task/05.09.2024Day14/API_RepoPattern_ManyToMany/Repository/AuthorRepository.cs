using API_ManyToMany.Interface;
using API_ManyToMany.Model;
using Microsoft.EntityFrameworkCore;

namespace API_ManyToMany.Repository
{
    public class AuthorRepository :IAuthor
    {
        private readonly BookDbContext _context;
        public AuthorRepository(BookDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            return await _context.Author.Include(b => b.bookAuthor!)
                 .ThenInclude(a => a.book).ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Author.Include(b => b.bookAuthor!).ThenInclude(a => a.book).FirstOrDefaultAsync(e => e.AuthorId == id) ?? throw new NullReferenceException();

        }

        public async Task AddAuthor(Author a)
        {
            await _context.Author.AddAsync(a);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int aid)
        {
            var b = await _context.Author.FindAsync(aid);
            if (b != null)
            {
                _context.Author.Remove(b);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAuthor(int id, Author a)
        {
            if (id == a.AuthorId)
            {
                _context.Entry(a).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
