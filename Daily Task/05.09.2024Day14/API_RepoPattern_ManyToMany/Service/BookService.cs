using API_ManyToMany.Interface;
using API_ManyToMany.Model;

namespace API_ManyToMany.Service
{
    public class BookService
    {
        private readonly IBook _book;
        public BookService(IBook b)
        {
            _book = b;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _book.GetAllBook();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _book.GetBookById(id);
        }

        public async Task AddBook(Book b)
        {
            await _book.AddBook(b);
        }

        public async Task DeleteBook(int id)
        {
            await _book.DeleteBook(id);
        }
        public async Task UpdateBook(int id, Book b)
        {
            await _book.UpdateBook(id,b);
        }



    }
}
