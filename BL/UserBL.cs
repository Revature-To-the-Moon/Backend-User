using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Models;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class UserBL : IBL
    {
        private readonly IRepo _repo;

        public UserBL(IRepo repo)
        {
            _repo = repo;
        }

        public async Task<Object> AddObjectAsync(Object objectToAdd)
        {
            return await _repo.AddObjectAsync(objectToAdd);
        }

        public async Task UpdateObjectAsync(Object objectToUpdate)
        {
            await _repo.UpdateObjectAsync(objectToUpdate);
        }

        public async Task DeleteObjectAsync(Object objectToDelete)
        {
            await _repo.DeleteObjectAsync(objectToDelete);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _repo.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _repo.GetUserByIdAsync(userId);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _repo.GetUserByNameAsync(username);
        }

        public async Task<List<FollowingPost>> GetFollowingPostsAsync()
        {
            return await _repo.GetFollowingPostsAsync();
        }

        public async Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId)
        {
            return await _repo.GetFollowingPostByRootIdAsync(rootId);
        }
        
        public async Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname)
        {
            return await _repo.GetFollowingPostByPostnameAsync(postname);
        }
        
        public async Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId)
        {
            return await _repo.GetFollowingPostByUserIdAsync(userId);
        }
        
        public async Task<List<Following>> GetAllFollowingAsync()
        {
            return await _repo.GetAllFollowingAsync();
        }
        
        public async Task<Following> GetFollowingByIdAsync(int followingId)
        {
            return await _repo.GetFollowingByIdAsync(followingId);
        }
        
        public async Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId)
        {
            return await _repo.GetFollowingByFollowerUserIdAsync(userId);
        }
    }
}