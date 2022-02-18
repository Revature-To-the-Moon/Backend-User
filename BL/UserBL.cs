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

        // ---------- Methods for User functionality ----------
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

        // ---------- Methods for FollowingPost functionality ----------
        public async Task<List<FollowingPost>> GetFollowingPostsAsync()
        {
            return await _repo.GetFollowingPostsAsync();
        }

        public async Task<FollowingPost> GetFollowingPostByIdAsync(int Id)
        {
            return await _repo.GetFollowingPostByIdAsync(Id);
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

        // ---------- Methods for Following functionality ----------
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

        public async Task<List<Following>> GetFollowerByUserIdAsync(int userId)
        {
            return await _repo.GetFollowerByUserIdAsync(userId);
        }

        // ---------- Methods for Grouping functionality ----------

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await _repo.GetAllGroupsAsync();
        }
        
        public async Task<Group> GetGroupByIdAsync(int groupId)
        {
            return await _repo.GetGroupByIdAsync(groupId);
        }
        
        public async Task<List<Group>> GetGroupsByGroupNameAsync(string searchTerm)
        {
            return await _repo.GetGroupsByGroupNameAsync(searchTerm);
        }

        // ---------- Methods for GroupMember functionality ----------

        public async Task<List<GroupMembers>> GetGroupsByUserIdAsync(int memberUserId)
        {
            return await _repo.GetGroupsByUserIdAsync(memberUserId);
        }

        public async Task RemoveMemberFromGroupAsync (int groupId, int memberUserId)
        {
            await _repo.RemoveMemberFromGroupAsync(groupId, memberUserId);
        }
    }
}