using Microsoft.EntityFrameworkCore;
using MVCAssessment.Models;
using MVCAssessment.Repository;

namespace MVCAssessment.Service
{
    public class UserService:IUser
    {
        private readonly UserContext _contxt;
        public UserService(UserContext contxt)
        {
            _contxt = contxt;
        }
        public IEnumerable<User> GetAll()
        {
            return _contxt.Users.Include(p=>p.Posts).ToList();
        }
        public User? GetUser(int id)
        {
            return _contxt.Users.FirstOrDefault(s => s.uId == id);
        }
       public void AddUser(User u)
        {
            _contxt.Add(u);
            _contxt.SaveChanges();
        }
       public void UpdateUser(int id, User u)
        {
            _contxt.Update(u);
            _contxt.SaveChanges();
        }
        public void DeleteUser(User u)
        {
            _contxt.Remove(u);
            _contxt.SaveChanges();
        }

    }
}
