using Microsoft.EntityFrameworkCore;
using Models;



namespace DL
{
    public class UserDB : DbContext
    {
        public UserDB() : base() { }

        public UserDB(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<FollowingPost> FollowingPosts { get; set; }
<<<<<<< HEAD

        public DbSet<Following> Following { get; set; }

=======
>>>>>>> 7bcf0903b953f4950e952dedd0511df872dd62c3
    }
}