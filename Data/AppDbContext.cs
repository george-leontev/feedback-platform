using Microsoft.EntityFrameworkCore;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Status> Status => Set<Status>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
