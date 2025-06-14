using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? Phone { get; set; }

    [SwaggerIgnore]
    public ICollection<Registration>? Registrations { get; set; }
}