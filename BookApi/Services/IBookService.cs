using BookApi.Dtos;
using BookApi.Models;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> AddBookAsync(AddBookRequest dto);
    }
}
