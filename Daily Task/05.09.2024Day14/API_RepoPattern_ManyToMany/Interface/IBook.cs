using API_ManyToMany.Model;

namespace API_ManyToMany.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBook();

        Task<Book> GetBookById(int id);

        Task AddBook(Book b);

        Task UpdateBook(int id, Book e);
        Task DeleteBook(int id);
    }
}
