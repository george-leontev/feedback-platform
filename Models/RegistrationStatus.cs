using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class RegistrationStatus
{
    public int Id { get; set; }

    public string Name { get; set; }

    [SwaggerIgnore]
    public ICollection<Registration>? Registrations { get; set; }
}