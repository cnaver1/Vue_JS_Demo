using API_Service.Classes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_Service.Services
{
   
    public interface IPostService 
    {
        Task<List<Post>> Get();
        Task<Post> Get(string id);
        Task<Post> Insert(Post post);
        Task<int> Delete(Post post);
    }

    public class PostService : IPostService
    {
        private readonly MyContext _myContext;

        public PostService(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<int> Delete(Post post)
        {
             _myContext.Posts.Remove(post);

            return await _myContext.SaveChangesAsync();
        }

        async public Task<List<Post>> Get()
        {
            return await _myContext.Posts.ToListAsync();
        }

         public async Task<Post> Get(string id)
        {
               return await _myContext.Posts.FindAsync(id);
        }

        public async Task<Post> Insert(Post post)
        {
            _myContext.Posts.Add(post);

            await _myContext.SaveChangesAsync();

            return await Get(post.Id);
        }
    }
}
