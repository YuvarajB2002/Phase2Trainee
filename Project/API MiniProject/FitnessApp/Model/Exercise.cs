using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Model
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

     
        public string? Name { get; set; }

        
        public int Difficulty { get; set; } // Difficulty rating (e.g., 1-5)

   
        public string? Description { get; set; }

        // Foreign key
        public int WorkoutPlanId { get; set; }

        [ForeignKey("WorkoutPlanId")]

        public  WorkoutPlan? WorkoutPlan { get; set; }
    }
}
