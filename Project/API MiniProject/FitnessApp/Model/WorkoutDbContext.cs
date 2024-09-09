using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Model
{
    public class WorkoutDbContext:DbContext
    {
        public DbSet<WorkoutPlan> workoutPlans { get; set; }
        public DbSet<Exercise> exercises { get; set; }

        public DbSet<User> users { get; set; }
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) { }

    }
}
