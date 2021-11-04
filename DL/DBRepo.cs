using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.User.Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList()
            }).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.User.Include(user => user.FollowingPosts).AsNoTracking().Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList()
            }).FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<User> GetUserByNameAsync(string username)
        {
            return await _context.User.Include(user => user.FollowingPosts).AsNoTracking().Select(user => new User()
            {
                Id = user.Id,
                Username = user.Username,
                FollowingPosts = user.FollowingPosts.Select(p => new FollowingPost()
                {
                    Id = p.Id,
                    RootId = p.RootId,
                    Postname = p.Postname,
                    UserId = p.UserId
                }).ToList()
            }).FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<FollowingPost>> GetFollowingPostsAsync()
        {
            return await _context.FollowingPost.Select(post => post).ToListAsync();
        }

        public async Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId)
        {
            return await _context.FollowingPost.AsNoTracking().FirstOrDefaultAsync(u => u.RootId == rootId);
        }

        public async Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname)
        {
            return await _context.FollowingPost.AsNoTracking().FirstOrDefaultAsync(u => u.Postname == postname);
        }
        public async Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId)
        {
            return await _context.FollowingPost.AsNoTracking().Where(u => u.UserId == userId).ToListAsync();
        }

    }
}