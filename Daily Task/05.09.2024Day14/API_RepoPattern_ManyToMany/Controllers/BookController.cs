using API_ManyToMany.Model;
using API_ManyToMany.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookser;
        public BookController(BookService bookser)
        {
            _bookser = bookser;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookser.GetBooks();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _bookser.GetBook(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book b)
        {
            await _bookser.AddBook(b);
            return Ok("Book Added Successfully");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book b)
        {
            await _bookser.UpdateBook(id, b);
            return Ok("Book Updated");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookser.DeleteBook(id);
            return Ok("Book deleted Successfully");
        }
    }
}
