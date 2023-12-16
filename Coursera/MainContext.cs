using Coursera.Extensions;
using Coursera.Models;
using Microsoft.EntityFrameworkCore;

namespace Coursera;

public class MainContext : DbContext
{
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {

    }

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

        modelBuilder.Entity<User>().ToTable("user");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
}
