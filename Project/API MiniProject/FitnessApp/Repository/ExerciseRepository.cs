using FitnessApp.Interface;
using FitnessApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FitnessApp.Repository
{
    public class ExerciseRepository:IExercise
    {
        private readonly WorkoutDbContext _context;
        public ExerciseRepository(WorkoutDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _context.exercises.Include(c => c.WorkoutPlan).ToListAsync();
        }

        public async Task<Exercise> GetExerciseById(int id)
        {
            return await _context.exercises.FirstOrDefaultAsync(c => c.ExerciseId == id);
        }

        public async Task AddExercise(Exercise e)
        {
            await _context.exercises.AddAsync(e);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExercise(int id, Exercise e)
        {
            if (id == e.ExerciseId)
            {
                _context.Entry(e).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
       public async Task DeleteExercise(int id)
        {
            var exe = await _context.exercises.FindAsync(id);
            if (exe != null)
            {
                _context.exercises.Remove(exe);
                await _context.SaveChangesAsync();
            }
        }

    
        
    }
}
