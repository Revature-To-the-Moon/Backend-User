using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private readonly UserDB _context;

        public DBRepo(UserDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Traditional method CRUD
        /// </summary>
        public async Task<Object> AddObjectAsync(Object objectToAdd)
        {
            await _context.AddAsync(objectToAdd);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
            return objectToAdd;
        }

        public async Task UpdateObjectAsync(Object objectToUpdate)
        {
            _context.Update(objectToUpdate);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
        public async Task DeleteObjectAsync(Object objectToDelete)
        {
            _context.Remove(objectToDelete);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        // ---------- Methods for User functionality ----------

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList(),
                Followings = _context.Following.Where(f => f.FollowerUserId == user.Id).Select(p => new Following()
                {
                    Id = p.Id,
                    FollowerUserId = p.FollowerUserId,
                    FollowingUserId = p.FollowingUserId,
                    FollowingUserName = p.FollowingUserName
                }).ToList()
            }).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Include(user => user.FollowingPosts).Include(user => user.Followings).AsNoTracking().Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList(),
                Followings = _context.Following.Where(f => f.FollowerUserId == user.Id).Select(p => new Following()
                {
                    Id = p.Id,
                    FollowerUserId = p.FollowerUserId,
                    FollowingUserId = p.FollowingUserId,
                    FollowingUserName = p.FollowingUserName
                }).ToList()
            }).FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _context.Users.Include(user => user.FollowingPosts).AsNoTracking().Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList(),
                Followings = _context.Following.Where(f => f.FollowerUserId == user.Id).Select(p => new Following()
                {
                    Id = p.Id,
                    FollowerUserId = p.FollowerUserId,
                    FollowingUserId = p.FollowingUserId,
                    FollowingUserName = p.FollowingUserName
                }).ToList()
            }).FirstOrDefaultAsync(u => u.Username == username);
        }

        // ---------- Methods for FollowingPost functionality ----------

        public async Task<List<FollowingPost>> GetFollowingPostsAsync()
        {
            return await _context.FollowingPosts.Select(post => post).ToListAsync();
        }

        public async Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId)
        {
            return await _context.FollowingPosts.AsNoTracking().FirstOrDefaultAsync(u => u.RootId == rootId);
        }

        public async Task<FollowingPost> GetFollowingPostByIdAsync(int Id)
        {
            return await _context.FollowingPosts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname)
        {
            return await _context.FollowingPosts.AsNoTracking().FirstOrDefaultAsync(u => u.Postname == postname);
        }
        public async Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId)
        {
            return await _context.FollowingPosts.AsNoTracking().Where(u => u.UserId == userId).Select(post => post).ToListAsync();
        }

        // ---------- Methods for Following functionality ----------

        public async Task<List<Following>> GetAllFollowingAsync()
        {
            return await _context.Following.Select(f => f).ToListAsync();
        }

        public async Task<Following> GetFollowingByIdAsync(int followingId)
        {
            return await _context.Following.AsNoTracking().FirstOrDefaultAsync(f => f.Id == followingId);
        }

        public async Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId)
        {
            return await _context.Following.Where(f => f.FollowerUserId == userId).Select(f => f).ToListAsync();
        }

        public async Task<List<Following>> GetFollowerByUserIdAsync(int userId)
        {
            return await _context.Following.Where(f => f.FollowingUserId == userId).Select(f => f).ToListAsync();
        }

        // ---------- Methods for Grouping functionality ----------

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.Select(g => g).ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int groupId)
        {
            return await _context.Groups.AsNoTracking().FirstOrDefaultAsync(g => g.Id == groupId);
        }
        
        public async Task<List<Group>> GetGroupsByGroupNameAsync(string searchTerm)
        {
            return await _context.Groups.Where(g => g.GroupName.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
        }
        
        // ---------- Methods for GroupMember functionality ----------

        public async Task<List<GroupMembers>> GetGroupsByUserIdAsync(int memberUserId)
        {
            return await _context.GroupMembers.Where(g => g.MemberUserId == memberUserId).Select(g => g).ToListAsync(); //Check if the user is a member of that certain group
        }

        public async Task RemoveMemberFromGroupAsync (int groupId, int memberUserId)
        {
            GroupMembers member;
             member = _context.GroupMembers.Where(g => g.GroupId == groupId && g.MemberUserId == memberUserId).First(); //
                        _context.Remove(member);
                        await _context.SaveChangesAsync();
                        _context.ChangeTracker.Clear();
        }
        
    }
}
