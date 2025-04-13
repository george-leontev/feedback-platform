using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CollegeFeedbackPlatform.Data;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _hasher;

    public UserRepository(AppDbContext context)
    {
        _context = context;
        _hasher = new PasswordHasher<User>();
    }

    public async Task<User> GetAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(t => t.Id == id);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    public async Task<User> PostAsync(User user)
    {
        user.Password = _hasher.HashPassword(user, user.Password);
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }
}
