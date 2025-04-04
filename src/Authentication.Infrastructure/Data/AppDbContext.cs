using Authentication.Domain.Entities;
using Authentication.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Auth?> Authentications { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("forlogic-api");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjectionExtension).Assembly);
    }
}
