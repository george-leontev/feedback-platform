using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class Status
{
    [SwaggerIgnore]
    public int Id { get; set; }

    public string Name { get; set; }
}