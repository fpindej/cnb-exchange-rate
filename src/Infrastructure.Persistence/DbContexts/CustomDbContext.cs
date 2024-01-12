using Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts;

public sealed class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicles");

            entity.Property(v => v.Vin)
                .HasColumnName("VehicleIdentificationNumber");

            entity.Property(v => v.Manufacturer)
                .HasConversion<string>(); // Convert enum to string in DB

            // Additional configurations...
        });

        // Other model configurations...
    }
}