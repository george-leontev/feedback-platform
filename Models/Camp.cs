using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class Camp
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    [SwaggerIgnore]
    public ICollection<RegistrationCamp>? RegistrationCamps { get; set; }
}
