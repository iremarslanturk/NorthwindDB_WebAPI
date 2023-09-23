using System.Text.Json;

namespace NorthWindDB_WebApi.Services

{
    public class JWTAuthManager
    {
        private readonly HttpClient _httpClient;
        private readonly string _authProviderUrl;
        public JWTAuthManager(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthApiClient");
            _authProviderUrl = "https://auth-provider.example.com"; // Örnek bir JWT sağlayıcısının URL'si
        }
        public async Task<string> GetJwtTokenAsync(string username, string password)
        {
            var requestData = new { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"{_authProviderUrl}/token", requestData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseData = JsonSerializer.Deserialize<AuthResponseData>(responseContent);
                return responseData.JwtToken;
            }
            else
            {
                throw new Exception("Kimlik doğrulama hatası.");
            }
        }
    }
    public class AuthResponseData
    {
        public string JwtToken { get; set; }
    }

}