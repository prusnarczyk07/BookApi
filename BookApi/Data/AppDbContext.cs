using Microsoft.EntityFrameworkCore;
using BookApi.Models;

namespace BookApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
    }
}
