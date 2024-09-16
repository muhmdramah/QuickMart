using Microsoft.EntityFrameworkCore;
using QuickMart_Ecommerce_API.Entities;

namespace QuickMart_Ecommerce_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
