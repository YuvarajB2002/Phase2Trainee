using API_ManyToMany.Interface;
using API_ManyToMany.Model;

namespace API_ManyToMany.Service
{
    public class AuthorService
    {
        private readonly IAuthor _auth;
        public AuthorService(IAuthor a)
        {
            _auth = a;
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _auth.GetAllAuthor();
        }

        public async Task<Author> GetAuthor(int id)
        {
            return await _auth.GetAuthorById(id);
        }

        public async Task AddAuthor(Author a)
        {
            await _auth.AddAuthor(a);
        }

        public async Task DeleteAuthor(int id)
        {
            await _auth.DeleteAuthor(id);
        }

        public async Task UpdateAuthor(int id, Author a)
        {
            await _auth.UpdateAuthor(id, a);
        }
    }
}
