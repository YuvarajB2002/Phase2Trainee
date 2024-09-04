using Microsoft.EntityFrameworkCore;

namespace MVCAssessment.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    }
}
