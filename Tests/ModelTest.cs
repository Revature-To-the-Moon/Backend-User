using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Models;

namespace Tests
{
    public class ModelTest
    {
        [Fact]
        public void UserShouldCreate()
        {
            User test = new User();
            Assert.NotNull(test);
        }

        [Fact]
        public void UserShouldSetValidData()
        {
            User test = new User(){
                Id = 1,
                Username = "testing"
            };

            Assert.Equal("testing", test.Username);
        }

        [Fact]
        public void FollowingPostShouldCreate()
        {
            FollowingPost test = new FollowingPost();
            Assert.NotNull(test);
        }

        [Fact]
        public void FollowingPostShouldSetValidData()
        {
            FollowingPost test = new FollowingPost(){
                Id = 1,
                Postname = "testing",
                RootId = 4,
                UserId =12
            };

            Assert.Equal("testing", test.Postname);
            Assert.Equal(4, test.RootId);
        }

        
    }
}