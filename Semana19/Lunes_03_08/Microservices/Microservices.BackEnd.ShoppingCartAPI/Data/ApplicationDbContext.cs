using Microservices.BackEnd.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.BackEnd.ShoppingCartAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
