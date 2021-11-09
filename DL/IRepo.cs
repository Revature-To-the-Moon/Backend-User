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
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByIdAsync(int userId);
        public Task<User> GetUserByNameAsync(string username);
        public Task<List<FollowingPost>> GetFollowingPostsAsync();
        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);
        public Task<List<Following>> GetAllFollowingAsync();
        public Task<Following> GetFollowingByIdAsync();
        public Task<List<Following>> GetFollowingByFollowerUserIdAnync(int userId);

    }
}