using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Repositories;

public interface IStatusRepository
{
    Task<IEnumerable<Status>> GetAllAsync();
}
