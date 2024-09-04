using Microsoft.EntityFrameworkCore;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Service
{
    public class PostService :IPost
    {
        private readonly UserContext _contxt;
        public PostService(UserContext contxt)
        {
            _contxt = contxt;
        }
        public IEnumerable<Post> GetAll()
        {
            return _contxt.Posts.Include(p => p.User).ToList();
        }
        public Post? GetPost(int id)
        {
            return _contxt.Posts.Include(u=>u.User).FirstOrDefault(p => p.PostId == id);
        }
        public void AddPost(Post p)
        {
            _contxt.Posts.Add(p);
            _contxt.SaveChanges();
        }

        public void UpdatePost(int id,Post p)
        {
            _contxt.Posts.Update(p);
            _contxt.SaveChanges();
        }

        public void DeletePost(Post p) { 

          _contxt.Posts.Remove(p);
            _contxt.SaveChanges();
        }
    }
}
