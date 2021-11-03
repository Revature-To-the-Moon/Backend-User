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
        public void FollowingPostShouldCreate()
        {
            FollowingPost test = new FollowingPost();
            Assert.NotNull(test);
        }
    }
}