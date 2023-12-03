
using Week3_Assessment.Models;

namespace Week3_Assessment.Services.IService
{
    public interface IUsers
    {
        Task<List<UserModels>> GetUsersAsync();

        Task<UserModels> GetUserByIdAsync(int id);


    }
}
