using FitnessApp.Model;
using FitnessApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        // GET: api/<ExerciseController>
        private readonly ExerciseService _exeser;
        private readonly WorkoutDbContext _context;

        public ExerciseController(ExerciseService ser,WorkoutDbContext context)
        {
            _exeser = ser;
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<IEnumerable<Exercise>> Get()
        {
            return await _exeser.GetAllExercise();
        }

        // GET api/<ExerciseController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<Exercise>> Get(int id)
        {
            var exe= await _exeser.GetExerciseById(id);
            if (exe == null)
            {
                return NotFound("Exercise not found");
            }
            else
            {
                return Ok(exe);
            }
        }

        // POST api/<ExerciseController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Exercise e)
        {
            await _exeser.AddExercise(e);
            return Ok("Exercise Added Successfully");
        }

        // PUT api/<ExerciseController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] Exercise e)
        {
            if (id != e.ExerciseId)
            {
                return NotFound("Exercise Id not found");
            }
            await _exeser.UpdateExercise(id, e);
            return Ok("Updated successfully");
        }

        // DELETE api/<ExerciseController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var exe = await _context.exercises.FindAsync(id);
            if (exe == null)
            {
                return NotFound("Exercise Id not found");
            }
            await _exeser.DeleteExercise(id);
            return Ok("Exercise deleted Successfully");
        }

        [HttpGet("count/difficulty/{difficulty}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<int>> GetExercisesCountByDifficulty(int difficulty)
        {
            var count = await _context.exercises.CountAsync(e => e.Difficulty == difficulty);
            if (count == 0)
            {
                return NotFound("No difficulty match in exercise");
            }
            return Ok(count);
        }

        [HttpGet("filter/name/{name}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercisesByName(string name)
        {
            var exercises = await _context.exercises
                .Where(e => e.Name.Contains(name))
                .ToListAsync();
            if (exercises.IsNullOrEmpty())
            {
                return NotFound("No Exercise Found for that Name");
            }
            return Ok(exercises);
        }

        [HttpGet("filter/workoutPlanId")]
        [Authorize(Roles = "User,Admin")]
        
        public async Task<IActionResult> ByWorkoutPlan([FromQuery] int workoutPlanId)
        {
            var exercises = await _context.exercises
                                           .Where(e => e.WorkoutPlanId == workoutPlanId)
                                           .ToListAsync();
            if (exercises.IsNullOrEmpty())
            {
                return NotFound("No workout plan IDs provided.");
            }
            return Ok(exercises); // Returns the data as JSON
        }
    }
}
