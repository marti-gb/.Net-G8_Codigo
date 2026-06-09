using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.Data;

public partial class G8DatabaseFirstContext : DbContext
{
    public G8DatabaseFirstContext()
    {
    }

    public G8DatabaseFirstContext(DbContextOptions<G8DatabaseFirstContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
