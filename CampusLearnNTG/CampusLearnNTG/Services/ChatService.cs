using System.Net.Http.Json;
using System.Text.Json;

namespace CampusLearnNTG.Services
{
    public class ChatService
    {
        private readonly HttpClient _http;

        public ChatService(IHttpClientFactory httpFactory)
        {
            _http = httpFactory.CreateClient("LmStudio");
        }

        public async Task<string> GetChatResponse(string userMessage)
        {
            var payload = new
            {
                model = "qwen/qwen3-1.7b",
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = userMessage }
                }
            };

            try
            {
                var response = await _http.PostAsJsonAsync("", payload);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);

                return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString()
                    ?? "[No response]";
            }
            catch (Exception ex)
            {
                return $"[Error: {ex.Message}]";
            }
        }
    }
}
