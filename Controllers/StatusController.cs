using Microsoft.AspNetCore.Mvc;
using CollegeFeedbackPlatform.Repositories;
using CollegeFeedbackPlatform.Models;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    public readonly IStatusRepository _statusRepository;

    public StatusController(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Status>> getAllAsync()
    {
        var statuses = await _statusRepository.GetAllAsync();

        return statuses;
    }
}