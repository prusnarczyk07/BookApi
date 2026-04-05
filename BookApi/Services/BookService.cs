using BookApi.Data;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using BookApi.Dtos;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext context;

        public BookService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> AddBookAsync(AddBookRequest dto)
        {
            Book newBook = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                Year = dto.Year
            };

            context.Books.Add(newBook);
            await context.SaveChangesAsync();
            return newBook;
        }
    }

}
