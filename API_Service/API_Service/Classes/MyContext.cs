using Microsoft.EntityFrameworkCore;

namespace API_Service.Classes
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
