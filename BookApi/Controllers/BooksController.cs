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
    }
}
