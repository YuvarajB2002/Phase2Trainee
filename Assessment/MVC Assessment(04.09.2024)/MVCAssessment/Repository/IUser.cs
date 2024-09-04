using MVCAssessment.Models;

namespace MVCAssessment.Repository
{
    public interface IUser
    {
        public IEnumerable<User> GetAll();

        User? GetUser(int id);
        void AddUser(User u);
        void UpdateUser(int id, User u);
        void DeleteUser(User u);
    }
}
