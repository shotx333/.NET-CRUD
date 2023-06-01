using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalDataController : ControllerBase
    {

        private readonly IUserService _userService;

        public ExternalDataController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("user/{userId}/posts")]
        public async Task<IActionResult> GetUserPosts(int userId)
        {
            // Get user from your database
            var user = _userService.GetUserById(userId);

            // If the user does not exist in your database, return a not found message
            if (user == null)
            {
                return NotFound("User not found");
            }

            // If the user exists, fetch their posts from the external API
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}/posts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonSerializer.Deserialize<List<Post>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                foreach (var post in posts)
                {
                    // Fetch comments for the post
                    var commentsResponse = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts/{post.Id}/comments");

                    if (commentsResponse.IsSuccessStatusCode)
                    {
                        var commentsContent = await commentsResponse.Content.ReadAsStringAsync();
                        post.Comments = JsonSerializer.Deserialize<List<Comment>>(commentsContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                }

                return Ok(posts);
            }
            else
            {
                return BadRequest("Unable to fetch posts");
            }
        }
        
        [HttpGet("user/{userId}/albums")]
        public async Task<IActionResult> GetUserAlbums(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}/albums");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var albums = JsonSerializer.Deserialize<List<Album>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(albums);
            }
            else
            {
                return BadRequest("Unable to fetch albums");
            }
        }

        [HttpGet("user/{userId}/todos")]
        public async Task<IActionResult> GetUserTodos(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}/todos");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var todos = JsonSerializer.Deserialize<List<Todo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(todos);
            }
            else
            {
                return BadRequest("Unable to fetch todos");
            }
        }



        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonSerializer.Deserialize<List<Post>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(posts);
            }
            else
            {
                return BadRequest("Unable to fetch posts");
            }
        }
        [HttpGet("comments")]
        public async Task<IActionResult> GetComments()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonSerializer.Deserialize<List<Comment>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(comments);
            }
            else
            {
                return BadRequest("Unable to fetch comments");
            }
        }

        [HttpGet("photos")]
        public async Task<IActionResult> GetPhotos()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var photos = JsonSerializer.Deserialize<List<Photo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(photos);
            }
            else
            {
                return BadRequest("Unable to fetch photos");
            }
        }
        
        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var todos = JsonSerializer.Deserialize<List<Todo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(todos);
            }
            else
            {
                return BadRequest("Unable to fetch todos");
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<User>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(users);
            }
            else
            {
                return BadRequest("Unable to fetch users");
            }
        }

        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbums()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/albums");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var albums = JsonSerializer.Deserialize<List<Album>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return Ok(albums);
            }
            else
            {
                return BadRequest("Unable to fetch albums");
            }
        }

    }
}
