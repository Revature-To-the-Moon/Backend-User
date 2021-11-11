using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using DL;
using Models;

namespace Tests
{
    public class MockRepo: Mock<IRepo>
    {
        public async Task<MockRepo> MockGetUsersAsync(Task<List<User>> results)
        {
            Setup(x => x.GetAllUsersAsync()).Returns(results);
            return this;
        }

        public async Task<MockRepo> MockGetFollowingPostsAsync(Task<List<FollowingPost>> results)
        {
            Setup(x => x.GetFollowingPostsAsync()).Returns(results);
            return this;
        }

        public async Task<MockRepo> MockGetFollowingsAsync(Task<List<Following>> results)
        {
            Setup(x => x.GetAllFollowingAsync()).Returns(results);
            return this;
        }
    }
}