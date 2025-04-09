using Microsoft.AspNetCore.Mvc;
using CollegeFeedbackPlatform.Repositories;

namespace CollegeFeedbackPlatform.Models;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;
    public TasksController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();

        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetAsync(int id)
    {
        var task = await _taskRepository.GetAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> PostAsync([FromBody] TaskItem task)
    {
        if (task == null)
        {
            return BadRequest("Invalid task data.");
        }

        var newTask = await _taskRepository.PostAsync(task);

        return newTask;
    }

    [HttpPut]
    public async Task<ActionResult<TaskItem>> UpdateAsync(TaskItem task)
    {
        var updatedTask = await _taskRepository.UpdateAsync(task);

        if (updatedTask == null)
        {
            return NotFound("Task was not found");
        }

        return updatedTask;
    }
}
