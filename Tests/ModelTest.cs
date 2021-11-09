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
            List<FollowingPost> posts = new List<FollowingPost>();
            User test = new User() {
                Id = 1,
                Username = "testing",
                FollowingPosts = posts
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
        [Fact]
        public void ToStringShouldReturnTheCorrectFormat()
        {
            List<FollowingPost> posts = new List<FollowingPost>();
            FollowingPost post = new FollowingPost();
            post.Postname = "testpost";
            post.RootId = 1;
            post.UserId = 1;
            posts.Add(post);
            User test = new User()
            {
                Id = 1,
                Username = "testing",
                FollowingPosts = posts
            };

            string result = test.ToString();

            Assert.Equal("Username: testing Following 1 Posts", result);
        }
        
        [Fact]
        public void FollowingShouldCreate()
        {
            Following test = new Following();
            Assert.NotNull(test);
        }

        [Fact]
        public void FollowingShouldSetValidData()
        {
            
            Following test = new Following() {
                Id = 1,
                FollowingUserName = "testing",
                FollowingUserId = 2
            };

            Assert.Equal("testing", test.FollowingUserName);
           
        }
        
    }
}