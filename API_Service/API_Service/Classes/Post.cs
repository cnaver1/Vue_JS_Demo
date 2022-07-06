namespace API_Service.Classes
{
    public class Post
    {

        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public string CreateBy { get; set; }
        public int Likes { get; set; }
        public string? Comments { get; set; }
    }
}
