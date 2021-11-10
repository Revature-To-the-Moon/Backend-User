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

        //---------------------------------------------methods for getting user ---------------------------------------------------------------
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int userId);
        public Task<User> GetUserByNameAsync(string username);

        //------------------------------------------------methods for get followingposts----------------------------------------------------------
        public Task<List<FollowingPost>> GetFollowingPostsAsync();
        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);

        //-------------------------------methods for get following --------------------------------------------------------------
        public Task<List<Following>> GetAllFollowingAsync();
        public Task<Following> GetFollowingByIdAsync(int followingId);
        public Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId);
        public Task<List<Following>> GetFollowerByUserIdAsync(int userId);
    }
}