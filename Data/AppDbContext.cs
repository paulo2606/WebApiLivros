using Microsoft.EntityFrameworkCore;

namespace WebApiLivros.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }   
        
        public DbSet<Model.AuthorModel> Authors { get; set; } = null!;
        public DbSet<Model.BookModel> Books { get; set; } = null!;
    }
}
