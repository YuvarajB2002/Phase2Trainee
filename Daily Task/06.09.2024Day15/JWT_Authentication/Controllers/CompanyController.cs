using APICodeFirst.Model;
using APICodeFirst.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // GET: api/<CompanyController>
        private readonly CompanyService _comser;
        public CompanyController(CompanyService comser)
        {
            _comser = comser;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IEnumerable<Company>> Get()
        {
            return await _comser.GetCompanies();
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<Company> Get(int id)
        {
            return await _comser.GetCompany(id);
        }

        // POST api/<CompanyController>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] Company c)
        {
            await _comser.AddComp(c);
            return Ok("Company Added Successfully");
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] Company c)
        {
            await _comser.UpdateComp(id, c);
            return Ok("Updated");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _comser.DeleteComp(id);
            return Ok("Company deleted Successfully");
        }
    }
}
