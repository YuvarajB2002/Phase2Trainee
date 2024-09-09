using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace FitnessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private readonly WorkoutDbContext _context;

        public WorkoutPlansController(WorkoutDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutPlans
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<WorkoutPlan>>> GetworkoutPlans()
        {
            return await _context.workoutPlans.Include(e=>e.Exercises).ToListAsync();
        }

        // GET: api/WorkoutPlans/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<WorkoutPlan>> GetWorkoutPlan(int id)
        {
            var workoutPlan = await _context.workoutPlans.FindAsync(id);

            if (workoutPlan == null)
            {
                return NotFound("Workoutplan not found");
            }

            return workoutPlan;
        }

        // PUT: api/WorkoutPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutPlan(int id, WorkoutPlan workoutPlan)
        {
            if (id != workoutPlan.WorkoutPlanId)
            {
                return BadRequest();
            }

            _context.Entry(workoutPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkoutPlanExists(id))
                {
                    return NotFound("Workoutplan not found");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WorkoutPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<WorkoutPlan>> PostWorkoutPlan(WorkoutPlan workoutPlan)
        {
            _context.workoutPlans.Add(workoutPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkoutPlan", new { id = workoutPlan.WorkoutPlanId }, workoutPlan);
        }

        [HttpGet("count/popularity/{popularity}")]
        public async Task<ActionResult<int>> GetWorkoutPlansCountByPopularity(int popularity)
        {
            var count = await _context.workoutPlans.CountAsync(wp => wp.Popularity == popularity);
            if (count == 0)
            {
                return NotFound("No Popularity match in workoutplan");
            }
            
            return Ok(count);
        }

        [HttpGet("filter/name/{Name}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<WorkoutPlan>>> GetWorkoutPlansByName(string Name)
        {
            var workoutPlans = await _context.workoutPlans.Include(e=>e.Exercises)
                .Where(wp => wp.Name.Contains(Name))
                .ToListAsync();

            if(workoutPlans.IsNullOrEmpty())
            {
                return NotFound("Workoutplan Name not found");
            }
            else
            {
                
                return Ok(workoutPlans);
            }

           
        }

        // GET: api/WorkoutPlan/filter/popularity?min={minPopularity}&max={maxPopularity}
        [HttpGet("filter/popularity")]
        [Authorize(Roles = "User,Admin")]
        public async Task<ActionResult<IEnumerable<WorkoutPlan>>> GetWorkoutPlansByPopularity([FromQuery] int minPopularity, [FromQuery] int maxPopularity)
        {
            var workoutPlans = await _context.workoutPlans
                .Where(wp => wp.Popularity >= minPopularity && wp.Popularity <= maxPopularity)
                .ToListAsync();
            if (workoutPlans.IsNullOrEmpty())
            {
                return NotFound("No popularity within this range");
            }
            return Ok(workoutPlans);
        }

        // DELETE: api/WorkoutPlans/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteWorkoutPlan(int id)
        {
            var workoutPlan = await _context.workoutPlans.FindAsync(id);
            if (workoutPlan == null)
            {
                return NotFound("Workoutplan not found");
            }

            _context.workoutPlans.Remove(workoutPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkoutPlanExists(int id)
        {
            return _context.workoutPlans.Any(e => e.WorkoutPlanId == id);
        }
    }
}
