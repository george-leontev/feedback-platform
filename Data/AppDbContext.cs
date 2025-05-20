using Microsoft.EntityFrameworkCore;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация User
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        // Конфигурация Registration
        modelBuilder.Entity<Registration>()
            .HasOne(r => r.User)
            .WithMany(u => u.Registrations)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Status)
            .WithMany(s => s.Registrations)
            .HasForeignKey(r => r.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.PaymentType)
            .WithMany(p => p.Registrations)
            .HasForeignKey(r => r.PaymentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Конфигурация связи многие-ко-многим между Registration и Camp
        modelBuilder.Entity<RegistrationCamp>()
            .HasKey(rc => new { rc.RegistrationId, rc.CampId });

        modelBuilder.Entity<RegistrationCamp>()
            .HasOne(rc => rc.Registration)
            .WithMany(r => r.Camps)
            .HasForeignKey(rc => rc.RegistrationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RegistrationCamp>()
            .HasOne(rc => rc.Camp)
            .WithMany(c => c.RegistrationCamps)
            .HasForeignKey(rc => rc.CampId)
            .OnDelete(DeleteBehavior.Cascade);

        // Начальные данные
        modelBuilder.Entity<RegistrationStatus>().HasData(
            new RegistrationStatus { Id = 1, Name = "Pending" },
            new RegistrationStatus { Id = 2, Name = "Confirmed" },
            new RegistrationStatus { Id = 3, Name = "Cancelled" }
        );

        modelBuilder.Entity<PaymentType>().HasData(
            new PaymentType { Id = 1, Name = "Cash" },
            new PaymentType { Id = 2, Name = "Credit Card" },
            new PaymentType { Id = 3, Name = "Bank Transfer" }
        );
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    public DbSet<Status> Status => Set<Status>();

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
