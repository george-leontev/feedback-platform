using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Services;

public interface IAuthenticationService
{
    Task<User?> AuthenticateAsync(string email, string password);
}
