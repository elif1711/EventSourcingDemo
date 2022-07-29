using Microsoft.EntityFrameworkCore;

namespace EventSourcing.API.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
