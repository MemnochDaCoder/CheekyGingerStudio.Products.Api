using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CheekyGingerStudioDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public CheekyGingerStudioDbContext(DbContextOptions<CheekyGingerStudioDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
