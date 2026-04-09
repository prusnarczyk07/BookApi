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

        public async Task<List<Book>> GetAllBooksAsync(string? genre, string? search, string? sortBy, int page = 0, int pageSize = 10)
        {
            var query = context.Books.AsQueryable();
            
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(b => b.Genre == genre);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Title.Contains(search));
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "title")
                    query = query.OrderBy(b => b.Title);
                else if (sortBy.ToLower() == "author")
                    query = query.OrderBy(b => b.Author);
                if (sortBy.ToLower() == "year")
                    query = query.OrderBy(b => b.Year);
            }

            var result = await query.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return result;
        }

        public async Task<List<string>> GetGenresAsync()
        {
            var genres = await context.Books
                .Select(b => b.Genre)
                .Distinct()
                .ToListAsync();
            return genres;
        }

        public async Task<List<string>> GetAuthorsAsync()
        {
            var authors = await context.Books
                .Select(b => b.Author)
                .Distinct()
                .ToListAsync();
            return authors;
        }

        public async Task<List<Book>> SearchBooksAsync(string search)
        {
            var result = await context.Books
                .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                .ToListAsync();

            return result;
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
