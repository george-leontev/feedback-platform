using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int StatusId { get; set; }

    [SwaggerIgnore]
    public Status? AssignedStatus { get; set; }
}
