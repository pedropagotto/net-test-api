using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  
    public DbSet<Auth> Authentications { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjectionExtension).Assembly);
    }
}
