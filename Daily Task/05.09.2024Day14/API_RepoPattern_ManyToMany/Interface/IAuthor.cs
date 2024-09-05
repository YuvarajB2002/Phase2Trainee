using API_ManyToMany.Model;

namespace API_ManyToMany.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthor();

        Task<Author> GetAuthorById(int id);

        Task AddAuthor(Author b);

        Task UpdateAuthor(int id, Author a);
        Task DeleteAuthor(int id);
    }
}
