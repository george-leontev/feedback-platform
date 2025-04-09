using CollegeFeedbackPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeFeedbackPlatform.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.Migrate();

        if (!context.Status.Any())
        {
            context.Status.AddRange(
                new Status { Name = "Open" },
                new Status { Name = "In Progress" },
                new Status { Name = "Completed" }
            );
        }

        if (!context.Users.Any())
        {
            context.Users.Add(new User
            {
                Username = "Egorchik",
                Password = "12345",
                IsAdmin = true
            });
        }

        if (!context.Tasks.Any())
        {
            context.Tasks.Add(new TaskItem
            {
                Title = "Add feature",
                Description = "Change color of button in production website",
                StatusId = 1
            });
        }

        context.SaveChanges();
    }
}
