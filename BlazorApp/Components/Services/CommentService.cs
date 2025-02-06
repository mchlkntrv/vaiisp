using Models;

namespace BlazorApp.Services
{
    public class CommentService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient("Api");

        public async Task<List<Comment>> GetCommentsByMineralIdAsync(int mineralId)
        {
            var response = await _httpClient.GetAsync($"api/comments/mineral/{mineralId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Comment>>() ?? new List<Comment>();
            }
            else
            {
                return new List<Comment>(); 
            }
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _httpClient.PostAsJsonAsync("api/comments", comment);
        }
    }
}
