using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Model
{
    public class WorkoutPlan
    {
        [Key]
        public int WorkoutPlanId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Popularity { get; set; }

        public  ICollection<Exercise>? Exercises { get; set; }
    }
}
