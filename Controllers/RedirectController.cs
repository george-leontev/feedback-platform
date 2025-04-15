using Microsoft.AspNetCore.Mvc;

namespace CollegeFeedbackPlatform.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult RedirectToSwagger()
    {
        return Redirect("/swagger");
    }
}
