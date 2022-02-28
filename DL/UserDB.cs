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

        public DbSet<Following> Following { get; set; }
    
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<GroupMembers> GroupMembers { get; set; }
    }
}

//After every change to models Last ran initMig3
//dotnet ef migrations add AddedGroupModels -c UserDB --startup-project ../WebAPI
//dotnet ef database update --startup-project ../WebAPI