using System;
using System.Threading.Tasks;
using Week3_Assessment.Models;
using Week3_Assessment.Services;
using Week3_Assessment.Services.IService;

namespace Week3_Assessment
{
    public class ServiceController
    {
        

       UserService _userService = new UserService();
       PostService _postService = new PostService();
       CommentsService _commentsService = new CommentsService();

       

        

        public async Task Initialize()
        {
            while (true)
            {
                Console.WriteLine("1. Display all users");
                Console.WriteLine("2. Select a user and display posts");
                Console.WriteLine("3. Select a post and display comments");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            await DisplayAllUsers();
                            break;
                        case 2:
                            await SelectUserAndDisplayPosts();
                            break;
                        case 3:
                            await SelectPostAndDisplayComments();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private async Task DisplayAllUsers()
        {
            var users = await _userService.GetUsersAsync();
            Console.WriteLine("Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.id}, Name: {user.name}, Username: {user.username}");
            }
        }

        private async Task SelectUserAndDisplayPosts()
        {
            Console.WriteLine("Enter user ID:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                var posts = await _postService.GetPostByUserId(userId);
                Console.WriteLine($"Posts for User ID {userId}:");
                foreach (var post in posts)
                {
                    Console.WriteLine($"Post ID: {post.id}, Title: {post.title}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        private async Task SelectPostAndDisplayComments()
        {
            Console.WriteLine("Enter post ID:");
            if (int.TryParse(Console.ReadLine(), out int postId))
            {
                var comments = await _commentsService.GetCommentByPostId(postId);
                Console.WriteLine($"Comments for Post ID {postId}:");
                foreach (var comment in comments)
                {
                    Console.WriteLine($"Comment ID: {comment.id}, Name: {comment.name}, Email: {comment.email}, Body: {comment.body}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
