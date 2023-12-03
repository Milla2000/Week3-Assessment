using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Week3_Assessment.Models;
using Week3_Assessment.Services.IService;

namespace Week3_Assessment.Services
{
    public class PostService : IPost
    {
        private readonly HttpClient _httpClient;
        private readonly string _Post_URL = "https://jsonplaceholder.typicode.com/posts";

        public PostService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<PostModel>> GetPostByUserId(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_Post_URL}?userId={userId}");
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<PostModel>>(content);


                if (response.IsSuccessStatusCode)
                {
                    return posts;
                }
                else
                {
                    return new List<PostModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<PostModel>();
            }
        }

        public async Task<List<PostModel>> GetAllPosts()
        {
            try
            {
                var response = await _httpClient.GetAsync(_Post_URL);
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<PostModel>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return posts;
                }
                else
                {
                    return new List<PostModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<PostModel>();
            }
        }
    }
}
