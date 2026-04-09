using BookApi.Dtos;
using BookApi.Models;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync(string? genre, string? search, string? sortBy, int page, int pageSize);
        Task<List<string>> GetGenresAsync();
        Task<List<string>> GetAuthorsAsync();
        Task<List<Book>> SearchBooksAsync(string search);
        Task<Book> AddBookAsync(AddBookRequest dto);
        Task<Book?> GetBookByIdAsync(int Id);
        Task<bool> DeleteBookByIdAsync(int Id);
        Task<Book?> UpdateBookAsync(int Id, UpdateBookRequest dto);
    }
}
