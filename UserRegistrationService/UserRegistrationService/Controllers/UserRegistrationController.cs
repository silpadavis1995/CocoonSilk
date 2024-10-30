using Microsoft.AspNetCore.Mvc;
using System.Text;
using UserRegistrationService.Models;
using System.Text.Json;

[ApiController]
[Route("api/[controller]")]
public class UserRegistrationController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public UserRegistrationController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistration user)
    {
        // Call your UserRegisterAPI here
        var jsonContent = JsonSerializer.Serialize(user);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");


        var response = await _httpClient.PostAsync("UserRegister/register", content);

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }

        return BadRequest();
    }
}
