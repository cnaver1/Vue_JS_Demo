using API_Service.Services;
using API_Service.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_Service.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<List<Post>> Get()
        {
            return await _postService.Get();
        }

        [HttpGet("{id}")]
        public async Task<Post> Get(string id)
        {
            return await _postService.Get(id);
        }

        [HttpPost]
        public async Task<Post> Insert(Post post)
        {
            return await _postService.Insert(post);
        }

        [HttpDelete]
        public async Task<int> Delete(Post post)
        {
            return await _postService.Delete(post);
        }
    }

}
