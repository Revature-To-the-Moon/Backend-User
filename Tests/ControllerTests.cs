using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using WebAPI.Controllers;
using Models;
using System.Text;
using Xunit;
using BL;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class ControllerTests
    {
        //UserController
        [Fact]
        public async Task GetUserShouldReturnListofUserAsync()
        {
            List<User> mockUser = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "test1"

                },
                new User()
                {
                    Id = 2,
                    Username = "test2"
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetAllUsersAsync()).ReturnsAsync(mockUser);
                
            UserController service = new UserController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockUser.Count());
        }

        [Fact]
        public async Task GetUserByIdShouldReturnUser()
        {
            User mockUser =  new User()
            {
                Id = 1,
                Username = "test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetUserByIdAsync(1)).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Get(1) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUserByNameShouldReturnUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetUserByNameAsync("Test1")).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Get("Test1") as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddShouldAddUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockUser)).ReturnsAsync(mockUser);

            UserController service = new UserController(mockBL.Object);

            var result = await service.Post(mockUser) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockUser, actualResult);
        }

        [Fact]
        public async Task UpdateShouldUpdateUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.UpdateObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Put(mockUser) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockUser, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Delete(mockUser.Id) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.Null(actualResult);
        }

        [Fact]
        public async Task DeleteByNameShouldDeleteUser()
        {
            User mockUser = new User()
            {
                Id = 1,

                Username = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockUser));

            UserController service = new UserController(mockBL.Object);

            var result = await service.Delete(mockUser.Username) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            //Assert.Null(actualResult);
        }

        //FollowingPostController
        [Fact]
        public async Task GetFollowingPostShouldReturnListofFollowingPostAsync()
        {
            List<FollowingPost> mockFollowingPost = new List<FollowingPost>()
            {
                new FollowingPost()
                {
                    Id = 1,
                    Postname = "test1"

                },
                new FollowingPost()
                {
                    Id = 2,
                    Postname = "test2"
                }
            };
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostsAsync()).ReturnsAsync(mockFollowingPost);
                
            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Get() as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(2, mockFollowingPost.Count());
        }

        [Fact]
        public async Task GetFollowingPostByRootIdShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost =  new FollowingPost()
            {
                Id = 1,
                Postname = "test1",
                RootId = 1
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostByRootIdAsync(1)).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByRootid(1) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByRootid(-1) as ObjectResult;
            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingPostByuserIdShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost =  new FollowingPost()
            {
                Id = 1,
                Postname = "test1",
                RootId = 1,
                UserId = 4
            };
            List<FollowingPost> followingPosts = new List<FollowingPost>();
            followingPosts.Add(mockFollowingPost);
            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.GetFollowingPostByUserIdAsync(4)).ReturnsAsync(followingPosts);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByUserid(4) as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByUserid(-1) as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task GetFollowingPostByNameShouldReturnFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();
            
            mockBL.Setup(x => x.GetFollowingPostByPostnameAsync("Test1")).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.GetByPostname("Test1") as ObjectResult;
            var actualResult = result.Value;
            var noresult = await service.GetByPostname("-Test") as ObjectResult;

            Assert.IsType<OkObjectResult>(result);
            Assert.Null(noresult);
        }

        [Fact]
        public async Task AddShouldAddFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.AddObjectAsync(mockFollowingPost)).ReturnsAsync(mockFollowingPost);

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Post(mockFollowingPost) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<CreatedResult>(result);
            Assert.Equal(HttpStatusCode.Created, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowingPost, actualResult);
        }

        [Fact]
        public async Task UpdateShouldUpdateFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1"
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.UpdateObjectAsync(mockFollowingPost));

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Put(mockFollowingPost) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.Equal(mockFollowingPost, actualResult);
        }

        [Fact]
        public async Task DeleteByIdShouldDeleteFollowingPost()
        {
            FollowingPost mockFollowingPost = new FollowingPost()
            {
                Id = 1,

                Postname = "Test1",
                RootId = 3
            };

            var mockBL = new Mock<IBL>();

            mockBL.Setup(x => x.DeleteObjectAsync(mockFollowingPost));

            FollowingPostController service = new FollowingPostController(mockBL.Object);

            var result = await service.Delete(mockFollowingPost.RootId) as ObjectResult;
            var actualResult = result.Value;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)result.StatusCode);
            Assert.NotNull(result);
        }
        
    }
}