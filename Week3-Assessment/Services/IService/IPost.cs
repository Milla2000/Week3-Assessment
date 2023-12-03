
using Week3_Assessment.Models;

namespace Week3_Assessment.Services.IService
{
    public interface IPost
    {
        Task<List<PostModel>> GetAllPosts();

        Task<List<PostModel>> GetPostByUserId(int userId);


    }
}
