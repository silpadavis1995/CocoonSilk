using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserRegistrationService.Models;

namespace UserRegistrationService.Services
{
    public class UserRegistrationServiceImplementation
    {
        private readonly HttpClient _httpClient;

        public UserRegistrationServiceImplementation(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> RegisterUserAsync(UserRegistration user)
        {
            var jsonContent = JsonSerializer.Serialize(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("UserRegister/register", content);
            if (!response.IsSuccessStatusCode)
            {
                // Log response content for debugging
                var responseContent = await response.Content.ReadAsStringAsync();
                // You can use a logger here
                Console.WriteLine($"Error: {response.StatusCode}, Content: {responseContent}");
                return false;
            }
            return true;
        }

    }
}
