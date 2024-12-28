using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase {

    [HttpPost("register")]
    public IActionResult Register([FromBody] DTO.RegistrationForm registrationForm) {

        // Check registration form validity
        if (!AuthenticationService.IsRegistrationFormValid(registrationForm))
            return BadRequest("Validation error.\n");

        // Add user data to DB
        if (AuthenticationService.RegisterUser(registrationForm))
            return Ok();
        else
            return StatusCode(500, "Internal server error.\n");
    }

    [HttpPost("verification/{id}")]
    public IActionResult Verification(int id) {
        return Ok($"received verification id {id}\n");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] DTO.Credentials credentials) {
        return Ok($"Received credentials {JsonSerializer.Serialize(credentials)}\n");
    }

}
