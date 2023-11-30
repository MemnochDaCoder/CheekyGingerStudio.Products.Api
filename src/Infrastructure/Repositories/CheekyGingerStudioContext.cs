using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Repositories
{
    public class CheekyGingerStudioContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
