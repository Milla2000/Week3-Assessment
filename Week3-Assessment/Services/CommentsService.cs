using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Week3_Assessment.Models;
using Week3_Assessment.Services.IService;

namespace Week3_Assessment.Services
{
    public class CommentsService : IComments
    {
        private readonly HttpClient _httpClient;
        private readonly string _Comments_URL = "https://jsonplaceholder.typicode.com/comments";

        public CommentsService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CommentModel>> GetAllComments()
        {
            try
            {
                var response = await _httpClient.GetAsync(_Comments_URL);
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
                else
                {
                    return new List<CommentModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<CommentModel>();
            }
        }

        public async Task<List<CommentModel>> GetCommentByPostId(int postId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_Comments_URL}?postId={postId}");
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
                else
                {
                    return new List<CommentModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<CommentModel>();
            }
        }
    }
}
