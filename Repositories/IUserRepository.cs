using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Repositories;

public interface IUserRepository
{
    Task<User> GetAsync(int id);

    Task<User> PostAsync(User user);
}
