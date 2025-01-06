using Models;

namespace BlazorApp.Services
{
    public class AuthService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient("Api");

        public async Task<bool> LoginAsync(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (loginResponse?.UserId != 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task LogoutAsync()
        {
            await _httpClient.PostAsync("api/auth/logout", null);
        }

        public async Task<int?> GetUserIdAsync()
        {
            var response = await _httpClient.GetAsync("api/auth/me");

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserResponse>();
                return user?.UserId;
            }

            return null;
        }

        public async Task<bool> IsUserLoggedInAsync()
        {
            var userId = await GetUserIdAsync();
            return userId != null;
        }
        public async Task<bool> RegisterAsync(RegistrationModel registrationModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/register", registrationModel);

            return response.IsSuccessStatusCode;
        }

        internal class UserResponse()
        {
            public string Username { get; set; }
            public int UserId { get; set; }
            public string Role { get; set; }

        }
    }
}