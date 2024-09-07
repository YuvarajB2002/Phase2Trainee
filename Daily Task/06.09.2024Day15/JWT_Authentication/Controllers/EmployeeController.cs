using APICodeFirst.Model;
using APICodeFirst.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _empser;
        public EmployeeController(EmployeeService empser)
        {
            _empser = empser;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Authorize(Roles ="Employee,Admin,Manager")]
        public async Task<IEnumerable<Employee> >Get()
        {
            return await _empser.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Employee,Admin,Manager")]
        public async Task<Employee> Get(int id)
        {
            return await _empser.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            await _empser.AddEmp(emp);
            return Ok("Employee Added Successfully");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee e)
        {
            await _empser.UpdateEmp(id, e);
            return Ok("Updated");
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empser.DeleteEmp(id);
            return Ok("Employee deleted Successfully");
        }
    }
}
