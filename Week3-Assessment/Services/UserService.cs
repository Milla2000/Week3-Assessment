
using Newtonsoft.Json;
using Week3_Assessment.Models;

namespace Week3_Assessment.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly string _User_URL = "https://jsonplaceholder.typicode.com/users ";

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<UserModels>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_User_URL);
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserModels>>(content);

                if (response.IsSuccessStatusCode && users !=null)
                {
                    return users;
                }
                else
                {
                    
                    return new List<UserModels>();
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}");
                return new List<UserModels>();
            }
        }

        
    }
}
