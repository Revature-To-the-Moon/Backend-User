using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public interface IRepo
    {
        public Task<Object> AddObjectAsync(Object objectToAdd);
        
        public Task UpdateObjectAsync(Object objectToUpdate);

        public Task DeleteObjectAsync(Object objectToDelete);

        // ---------- Methods for User functionality ----------

        public Task<List<User>> GetAllUsersAsync();
        
        public Task<User> GetUserByIdAsync(int userId);
        
        public Task<User> GetUserByNameAsync(string username);

        // ---------- Methods for FollowingPost functionality ----------

        public Task<List<FollowingPost>> GetFollowingPostsAsync();
        
        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);
        
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);

        // ---------- Methods for Following functionality ----------

        public Task<List<Following>> GetAllFollowingAsync();
        
        public Task<Following> GetFollowingByIdAsync(int followingId);
        
        public Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId);
        
        public Task<List<Following>> GetFollowerByUserIdAsync(int userId);
    }
}