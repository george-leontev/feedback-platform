using CollegeFeedbackPlatform.Data;
using CollegeFeedbackPlatform.Models;
using CollegeFeedbackPlatform.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class RecoverPasswordService : IRecoverPasswordService
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _hasher;
    private readonly IEmailService _emailService;

    public RecoverPasswordService(AppDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
        _hasher = new PasswordHasher<User>();
    }

    public async Task<bool> RecoverPasswordAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return false;
        }

        var newPassword = Guid.NewGuid().ToString("N")[..8];

        user.Password = _hasher.HashPassword(user, newPassword);

        await _context.SaveChangesAsync();

        string subject = "Your new password";
        string body = $"Hello, your new temporary password is: {newPassword}";

        await _emailService.SendEmailAsync(email, subject, body);

        return true;
    }
}
