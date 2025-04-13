using Microsoft.EntityFrameworkCore;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    public DbSet<Status> Status => Set<Status>();

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
