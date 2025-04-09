using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class User
{
    [SwaggerIgnore]
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; } = false;
}
