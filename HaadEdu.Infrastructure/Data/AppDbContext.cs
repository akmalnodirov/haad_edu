using HaadEdu.Domain.Entities;
using HaadEdu.Shared.Extensions;
using Microsoft.EntityFrameworkCore;


namespace HaadEdu.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<Language> Languages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToSnakeCase());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToSnakeCase());
            }
        }

        modelBuilder.Entity<Language>().ToTable("languages");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Role>().ToTable("roles")
            .HasIndex(r => r.Name)
            .IsUnique();
        modelBuilder.Entity<RolePermission>().ToTable("role_permissions");

        modelBuilder.Entity<User>()
           .HasOne(u => u.Role)
           .WithOne()
           .HasForeignKey<User>(u => u.RoleId);

        modelBuilder.Entity<RolePermission>()
           .HasOne(u => u.Role)
           .WithOne()
           .HasForeignKey<RolePermission>(u => u.RoleId);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.RolePermissions)
            .WithOne(rp => rp.Role)
            .HasForeignKey(rp => rp.RoleId);

        base.OnModelCreating(modelBuilder);
    }
}
