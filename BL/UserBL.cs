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
        
        public Task<List<Following>> GetAllFollowingAsync()
        {
            throw new NotImplementedException();
        }
        
        public Task<Following> GetFollowingByIdAsync()
        {
            throw new NotImplementedException();
        }
        
<<<<<<< HEAD
        public async Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId)
        {
            return await _repo.GetFollowingByFollowerUserIdAsync(userId);
        }

        public async Task<List<Following>> GetFollowerByUserIdAsync(int userId)
        {
            return await _repo.GetFollowerByUserIdAsync(userId);
=======
        public Task<List<Following>> GetFollowingByFollowerUserIdAnync(int userId)
        {
            throw new NotImplementedException();
>>>>>>> 7bcf0903b953f4950e952dedd0511df872dd62c3
        }
    }
}