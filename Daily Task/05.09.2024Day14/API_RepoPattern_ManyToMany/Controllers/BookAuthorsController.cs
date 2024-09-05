using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ManyToMany.Model;
using System.Net;
using API_ManyToMany.Service;

namespace API_ManyToMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly AuthorService _author;
        private readonly BookService _book;
        public BookAuthorsController(AuthorService author, BookService book)
        {
            _author = author;
            _book = book;
        }

        
        [HttpGet("Author/{authorId}")]
        public async Task<IActionResult> GetBookAuthorByAuthorId(int authorId)
        {
            var author = await _author.GetAuthor(authorId);

            if (author == null) return NotFound();

            var books = author.bookAuthor;
            return Ok(books);
        }

        // GET: api/<BookAuthorController>/Book/5
        [HttpGet("Book/{bookId}")]
        public async Task<IActionResult> GetBookAuthorByBookId(int bookId)
        {
            var book = await _book.GetBook(bookId);

            if (book == null) return NotFound();

            var authors = book.bookAuthor;
            return Ok(authors);
        }

        // POST api/<BookAuthorController>
        [HttpPost]
        public async Task<IActionResult> EnrollStudentInCourse([FromBody] BookAuthor bookAuthor)
        {
            if (bookAuthor == null)
            {
                return BadRequest("BookAuthor cannot be null");
            }

            // Fetch the author and book to verify they exist
            var author = await _author.GetAuthor(bookAuthor.AuthorId);
            var book = await _book.GetBook(bookAuthor.BookId);

            if (author == null || book == null)
            {
                return NotFound("Author or Book not found");
            }

            // Check if the author is already enrolled in the books
            var existingEnrollment = author.bookAuthor?
                                            .FirstOrDefault(sc => sc.BookId == bookAuthor.BookId);
            if (existingEnrollment != null)
            {
                return Conflict("Author is already added in this book");
            }

            // Add the student-course relationship
            author.bookAuthor?.Add(bookAuthor);
            book.bookAuthor?.Add(bookAuthor);

            // Update both the student and course entities in the database
            await _author.UpdateAuthor(author.AuthorId, author);
            await _book.UpdateBook(book.BookId, book);

            return CreatedAtAction(nameof(GetBookAuthorByAuthorId), new { studentId = bookAuthor.AuthorId }, bookAuthor);
        }

        // DELETE api/<BookAuthorController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(BookAuthor bookAuthor)
        {
            if (bookAuthor == null) return BadRequest("BookAuhtor can not be null");

            var author = await _author.GetAuthor(bookAuthor.AuthorId);
            var book = await _book.GetBook(bookAuthor.BookId);

            if (author == null || book == null) return BadRequest("Author or Book not found");

            author.bookAuthor!.Remove(bookAuthor);
            book.bookAuthor!.Remove(bookAuthor);

            await _author.UpdateAuthor(author.AuthorId, author);
            await _book.UpdateBook(book.BookId, book);

            return Ok("BookAuthor Deleted.");
        }
    }
}
