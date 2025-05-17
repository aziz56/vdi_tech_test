using Microsoft.EntityFrameworkCore;
using Technical_TestVDI.Models;
namespace Technical_TestVDI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DiscountEntity> Discounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
