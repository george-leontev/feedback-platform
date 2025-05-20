using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class PaymentType
{
    public int Id { get; set; }

    public string Name { get; set; }

    [SwaggerIgnore]
    public ICollection<Registration>? Registrations { get; set; }
}