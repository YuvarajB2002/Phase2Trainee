using MVCAssessment.Models;

namespace MVCAssessment.Repository
{
    public interface IPost
    {
        public IEnumerable<Post> GetAll();

        Post? GetPost(int id);
        void AddPost(Post p);
        void UpdatePost(int id,Post p);
        void DeletePost(Post p);
    }
}
