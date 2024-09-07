using Microsoft.EntityFrameworkCore;

namespace APICodeFirst.Model
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companys { get; set; }

        public DbSet<User> Users { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }


    }
}
