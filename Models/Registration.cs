using Swashbuckle.AspNetCore.Annotations;

namespace CollegeFeedbackPlatform.Models;

public class Registration
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? City { get; set; }

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }

    public int StatusId { get; set; } = 1;

    public int PaymentTypeId { get; set; }

    [SwaggerIgnore]
    public User? User { get; set; }

    [SwaggerIgnore]
    public RegistrationStatus? Status { get; set; }

    [SwaggerIgnore]
    public PaymentType? PaymentType { get; set; }

    [SwaggerIgnore]
    public ICollection<RegistrationCamp>? Camps { get; set; }
}