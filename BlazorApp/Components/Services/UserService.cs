using Models; 

namespace BlazorApp.Services
{
    public class UserService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient("Api");

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _httpClient.GetFromJsonAsync<User>($"api/user/{userId}");
                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public async Task<bool> IsUserAdminAsync()
        {
            try
            {
                var user = await _httpClient.GetFromJsonAsync<User>("api/auth/me");
                return user?.Role == "admin";
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
