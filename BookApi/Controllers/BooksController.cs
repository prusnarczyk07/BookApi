using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Services;
using BookApi.Data;
using BookApi.Dtos;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await service.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(AddBookRequest dto)
        {
            var book = await service.AddBookAsync(dto);

            return Ok(new { message = "Book was created successfully", data = book });
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBookById(int Id)
        {
            var book = await service.GetBookByIdAsync(Id);

            if (book == null)
                return NotFound("Book not found");
        
            return Ok(book);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Book>> DeleteBookById(int Id)
        {
            var success = await service.DeleteBookByIdAsync(Id);

            if (!success)
                return NotFound("Book not found");

            return Ok("Book deleted successfully");
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Book>> UpdateBook(int Id, UpdateBookRequest dto)
        {
            var book = await service.UpdateBookAsync(dto, Id);

            return Ok(new { message = "Book was updated successfully", data = book });
        }
    }
}
