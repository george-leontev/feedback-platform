using Microsoft.EntityFrameworkCore;
using CollegeFeedbackPlatform.Data;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        var tasks = await _context.Tasks.Include(t => t.AssignedStatus).ToListAsync();

        return tasks;
    }

    public async Task<TaskItem> GetAsync(int taskId)
    {
        var task = await _context.Tasks
            .Include(t => t.AssignedStatus)
            .FirstOrDefaultAsync(t => t.Id == taskId);

        if (task is null)
        {
            return null;
        }

        return task;
    }

    public async Task<TaskItem> PostAsync(TaskItem task)
    {
        var newTask = await _context.Tasks.AddAsync(task);

        await _context.SaveChangesAsync();

        return newTask.Entity;
    }

    public async Task<TaskItem> UpdateAsync(TaskItem task)
    {
        var updatedTask = await _context.Tasks.FindAsync(task.Id);

        if (updatedTask == null)
        {
            return null;
        }

        updatedTask.Title = task.Title;
        updatedTask.Description = task.Description;
        updatedTask.StatusId = task.StatusId;

        await _context.SaveChangesAsync();

        return updatedTask;
    }

    public async Task<TaskItem> DeleteAsync(int taskId)
    {
        var deletedTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

        if (deletedTask is null)
        {
            return null;
        }

        _context.Tasks.Remove(deletedTask);
        await _context.SaveChangesAsync();

        return deletedTask;
    }
}
