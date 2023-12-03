using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3_Assessment.Models;

namespace Week3_Assessment.Services.IService
{
    public interface IComments
    {
        Task<List<CommentModel>> GetAllComments();

        Task<List<CommentModel>> GetCommentByPostId(int postId);
    }
}
