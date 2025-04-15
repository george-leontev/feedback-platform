using Microsoft.AspNetCore.Mvc;
using CollegeFeedbackPlatform.Repositories;
using CollegeFeedbackPlatform.Services;
using CollegeFeedbackPlatform.Models;

namespace CollegeFeedbackPlatform.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authService;
    public UsersController(IUserRepository userRepository, IAuthenticationService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetAsync(int id)
    {
        var user = await _userRepository.GetAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostAsync([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("Invalid user data.");
        }

        var newUser = await _userRepository.PostAsync(user);

        return newUser;
    }

    [HttpPost("auth")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthUser authUser)
    {
        var user = await _authService.AuthenticateAsync(authUser.Email, authUser.Password);
        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        return Ok(user);
    }
}
