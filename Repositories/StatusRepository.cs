using CollegeFeedbackPlatform.Data;
using CollegeFeedbackPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeFeedbackPlatform.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly AppDbContext _context;

    public StatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Status>> GetAllAsync()
    {
        var statuses = await _context.Status.ToListAsync();

        if (statuses is null)
        {
            return null;
        }

        return statuses;
    }
}