using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfraestructureLayer.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
