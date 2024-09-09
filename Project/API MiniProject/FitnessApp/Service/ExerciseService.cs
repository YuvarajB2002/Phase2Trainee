using FitnessApp.Interface;
using FitnessApp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FitnessApp.Service
{
    public class ExerciseService
    {
        private readonly IExercise _exer;
        public ExerciseService(IExercise exer)
        {
            _exer= exer;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercise()
        {
            return await _exer.GetAllExercises();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await _exer.GetExerciseById(id);
        }

        public async Task AddExercise(Exercise e)
        {
            await _exer.AddExercise(e);
        }

        public async Task DeleteExercise(int id)
        {
            await _exer.DeleteExercise(id);
        }

        public async Task UpdateExercise(int id, Exercise e)
        {
            await _exer.UpdateExercise(id, e);
        }

        
    }
}
