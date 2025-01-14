using CardapioMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CardapioMVC.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet <Prato> Pratos { get; set; }
    }
}
