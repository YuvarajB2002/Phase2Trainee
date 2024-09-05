using API_ManyToMany.Model;
using API_ManyToMany.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _autser;
        public AuthorController(AuthorService autser)
        {
            _autser = autser;
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _autser.GetAuthors(); 
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _autser.GetAuthor(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author a)
        {
            await _autser.AddAuthor(a);
            return Ok("Author Added Successfully");
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Author a)
        {
            await _autser.UpdateAuthor(id, a);
            return Ok("Author Updated");
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _autser.DeleteAuthor(id);
            return Ok("Author deleted Successfully");
        }
    }
}
