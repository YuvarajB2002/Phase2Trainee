using FitnessApp.Model;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FitnessApp.Interface
{
    public interface IExercise
    {
        Task<IEnumerable<Exercise>> GetAllExercises();

        Task<Exercise> GetExerciseById(int id);

        Task AddExercise(Exercise company);

        Task UpdateExercise(int id, Exercise c);
        Task DeleteExercise(int id);

        
    }
}
