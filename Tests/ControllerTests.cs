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
    }
}