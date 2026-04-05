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

        public async Task<Book?> UpdateBookAsync(int Id, UpdateBookRequest dto)
        {
            var book = await context.Books.FindAsync(Id);

            if (book == null)
                return null;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Genre = dto.Genre;
            book.Year = dto.Year;

            await context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> GetBookByIdAsync(int Id)
        {
            var book = await context.Books.FindAsync(Id);
            return book;
        }

        public async Task<bool> DeleteBookByIdAsync(int Id)
        {
            var book = await context.Books.FindAsync(Id);

            if (book is null)
                return false;

            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;

        }
    }

}
