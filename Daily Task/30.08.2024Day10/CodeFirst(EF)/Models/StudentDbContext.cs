using Microsoft.EntityFrameworkCore;

namespace EFCORE.Models
{
    public class StudentDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>()
            //    .HasMany( s => s.Student)
            //    .WithOne(s => s.Department)
            //    .HasForeignKey(s => s.DepartmentId);
        }
    }
}
