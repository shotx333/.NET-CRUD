
namespace DataAccessLayer.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<Comment> Comments {get;set;}
    }

}
