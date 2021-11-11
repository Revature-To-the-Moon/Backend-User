using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Xunit;
using Models;

namespace Tests
{
    public class BLTests
    {

        [Fact]
        public async void GetAllUsersAsyncShouldReturn()
        {
            var mkusers = GetMockUsers();
            var mkrepo = await new MockRepo().MockGetUsersAsync(mkusers);
            var _bl = new UserBL(mkrepo.Object);
            var result = await _bl.GetAllUsersAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllFollowingPostsAsyncShouldReturn()
        {
            var mkfp = GetMockFollowingPosts();
            var mkrepo = await new MockRepo().MockGetFollowingPostsAsync(mkfp);
            var _bl = new UserBL(mkrepo.Object);
            var result = await _bl.GetFollowingPostsAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async void GetAllFollowingsAsyncShouldReturn()
        {
            var mkf = GetMockFollowings();
            var mkrepo = await new MockRepo().MockGetFollowingsAsync(mkf);
            var _bl = new UserBL(mkrepo.Object);
            var result = await _bl.GetAllFollowingAsync();

            Assert.Equal(2, result.Count);
        }

        //------------------------Mock Data -----------------------------------
        private async Task<List<User>> GetMockUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 3,
                    Username = "test1"
                },
                new User()
                {
                    Id = 2,
                    Username = "test3"
                }
            };
        }

        private async Task<List<FollowingPost>> GetMockFollowingPosts()
        {
            return new List<FollowingPost>()
            {
                new FollowingPost()
                {
                    Id = 1,
                    UserId = 3,
                    RootId = 7
                },
                new FollowingPost()
                {
                    Id = 2,
                    UserId = 2,
                    RootId = 8
                }
            };
        }

        private async Task<List<Following>> GetMockFollowings()
        {
            return new List<Following>()
            {
                new Following()
                {
                    Id = 1,
                    FollowerUserId = 3,
                    FollowingUserId = 2,
                    FollowingUserName = "test3"
                },
                new Following()
                {
                    Id = 2,
                    FollowerUserId = 2,
                    FollowingUserId = 3,
                    FollowingUserName = "test1"
                }
            };
        }
    }
}