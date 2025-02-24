using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence;

public sealed class FinancialManagementDbContext(DbContextOptions<FinancialManagementDbContext> options) : DbContext(options)
{
    private const string Schema = "dbo";

    public DbSet<UserModel> Users { get; init; } = default!;
    public DbSet<SettingsModel> Settings { get; init; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.Entity<UserModel>(entity => {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.FirstName).HasMaxLength(50);
            entity.Property(x => x.LastName).HasMaxLength(50);
            entity.Property(x => x.Email).HasMaxLength(100);
            entity.Property(x => x.PhoneNumber).HasMaxLength(30);

            entity.HasIndex(x => x.Email).IsUnique();
            entity.HasIndex(x => x.PhoneNumber).IsUnique();
        });

        modelBuilder.Entity<SettingsModel>(entity => {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.LastUserLoggedInEmail).HasMaxLength(100);
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>()
            .HaveMaxLength(4000);

        configurationBuilder.Properties<decimal>()
            .HavePrecision(19, 4);
        base.ConfigureConventions(configurationBuilder);
    }
}