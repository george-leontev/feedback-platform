using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Repositories;

public interface ITaskRepository
{
    Task<TaskItem> GetAsync(int id);

    Task<IEnumerable<TaskItem>> GetAllAsync();

    Task<TaskItem> PostAsync(TaskItem task);

     Task<TaskItem> UpdateAsync(TaskItem task);
}
