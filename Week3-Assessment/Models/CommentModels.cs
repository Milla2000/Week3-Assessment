namespace Week3_Assessment.Models
{
    public class CommentModel
    {
        public int postId { get; set; }

        public int id { get; set; }

        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string body { get; set; } = string.Empty;
    }
}
