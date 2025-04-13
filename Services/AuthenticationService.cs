using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CollegeFeedbackPlatform.Models;
using CollegeFeedbackPlatform.Data;

namespace CollegeFeedbackPlatform.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _hasher;

    public AuthenticationService(AppDbContext context)
    {
        _context = context;
        _hasher = new PasswordHasher<User>();
    }

    public async Task<User?> AuthenticateAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return null;
        }

        var result = _hasher.VerifyHashedPassword(user, user.Password, password);
        return result == PasswordVerificationResult.Success ? user : null;
    }
}
