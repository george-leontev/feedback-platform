using Microsoft.AspNetCore.Mvc;
using CollegeFeedbackPlatform.Repositories;
using CollegeFeedbackPlatform.Services;
using CollegeFeedbackPlatform.Models;
using Microsoft.AspNetCore.Identity;

namespace CollegeFeedbackPlatform.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthenticationService _authService;
    private readonly IRecoverPasswordService _recoverPasswordService;
    private readonly PasswordHasher<User> _hasher;

    public UsersController(IUserRepository userRepository, IAuthenticationService authService, IRecoverPasswordService recoverPasswordService)
    {
        _userRepository = userRepository;
        _authService = authService;
        _hasher = new PasswordHasher<User>();
        _recoverPasswordService = recoverPasswordService;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return Ok(users);
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

    [HttpPost("recover-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] string email)
    {
        var success = await _recoverPasswordService.RecoverPasswordAsync(email);

        if (!success)
        {
            return NotFound("User with this email was not found");
        }

        return Ok("New password has been sent to your email.");
    }
}
