using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class RegistrationCamp
{
    [ForeignKey("Registration")]
    public int RegistrationId { get; set; }

    [ForeignKey("Camp")]
    public int CampId { get; set; }

    [SwaggerIgnore]
    public Registration? Registration { get; set; }

    [SwaggerIgnore]
    public Camp? Camp { get; set; }
}