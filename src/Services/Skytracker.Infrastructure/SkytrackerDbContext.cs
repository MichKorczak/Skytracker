using Microsoft.EntityFrameworkCore;
using Skytracker.Domain.Entities;
using Skytracker.Infrastructure.EntityConfigurations;

namespace Skytracker.Infrastructure;

public class SkytrackerDbContext : DbContext
{
    public SkytrackerDbContext(DbContextOptions<SkytrackerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new FlightEntityTypeConfiguration());
    }
}
