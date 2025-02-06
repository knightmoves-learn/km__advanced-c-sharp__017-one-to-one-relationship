using Microsoft.EntityFrameworkCore;

namespace HomeEnergyApi.Models
{
    public class HomeDbContext : DbContext
    {
        public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }

        public DbSet<Home> Homes { get; set; }
    }
}