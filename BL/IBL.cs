using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// Generic method to add a corresponding Object to the database
        /// </summary>
        /// <param name="objectToAdd"></param>
        /// <returns>corresponding object from the DB</returns>
        public Task<Object> AddObjectAsync(Object objectToAdd);
        /// <summary>
        /// Generic method to update a corresponding Object in the database
        /// </summary>
        /// <param name="objectToUpdate"></param>
        /// <returns></returns>
        public Task UpdateObjectAsync(Object objectToUpdate);
        /// <summary>
        /// Generic method to delete a corresponding Object from the database
        /// </summary>
        /// <param name="objectToDelete"></param>
        /// <returns></returns>
        public Task DeleteObjectAsync(Object objectToDelete);
        /// <summary>
        /// Gets all the users from the database 
        /// </summary>
        /// <returns>List of all users.</returns>

        public Task<List<User>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by their Id from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A user.</returns>
        public Task<User> GetUserByIdAsync(int userId);

        /// <summary>
        /// Gets a user by their name from the database
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A User</returns>
        public Task<User> GetUserByNameAsync(string username);

        /// <summary>
        /// Gets all the followingposts from the database
        /// </summary>
        /// <returns>Lists of following posts.</returns>
        public Task<List<FollowingPost>> GetFollowingPostsAsync();
        /// <summary>
        /// Gets the following post by the root comment id from the database.
        /// </summary>
        /// <param name="rootId"></param>
        /// <returns>Following post</returns>

        public Task<FollowingPost> GetFollowingPostByRootIdAsync(int rootId);

        /// <summary>
        /// Gets following post by their name from the database.
        /// </summary>
        /// <param name="postname"></param>
        /// <returns>Following post</returns>
        public Task<FollowingPost> GetFollowingPostByPostnameAsync(string postname);
        /// <summary>
        /// Gets all the following post by User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of following posts.</returns>
        public Task<List<FollowingPost>> GetFollowingPostByUserIdAsync(int userId);
        
        /// <summary>
        /// Gets all following from the database
        /// </summary>
        /// <returns></returns>
        public Task<List<Following>> GetAllFollowingAsync();

        public Task<Following> GetFollowingByIdAsync(int followingId);

        public Task<List<Following>> GetFollowingByFollowerUserIdAsync(int userId);
        public Task<List<Following>> GetFollowerByUserIdAsync(int userId);
    }

}