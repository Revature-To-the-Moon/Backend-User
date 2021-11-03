using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Models;

namespace Tests
{
    public class DLTests
    {
        private DbContextOptions<UserDB> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<UserDB>().UseSqlite("Filename= Test.db").Options;
            Seed();
        }

        [Fact]
        public async void GetAllUsersShouldGetAllUsers()
        {
            using var context = new UserDB(options);

            IRepo repo = new DBRepo(context);

            List<User> users =  await repo.GetAllUsersAsync();

            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
           
        }

        [Fact]
        public async void AddingUserShouldAddUser()
        {
            using(var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 3,
                    Username = "Test3"
                };

                repo.AddObjectAsync(userToAdd);

            }
            using(var context = new UserDB(options))
            {
                User user = await context.User.FirstOrDefaultAsync(u => u.Id == 3);

                Assert.NotNull(user);
                Assert.Equal("Test3", user.Username);
            }
        }

        [Fact]
        public async void UpdateUserShouldUpdateUser()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);
                User userToAdd = new User()
                {
                    Id = 4,
                    Username = "Test4"
                };

                repo.AddObjectAsync(userToAdd);

                User userToUpdate = new User()
                {
                    Id = 4,
                    Username = "TestUpdate"
                };

                repo.UpdateObjectAsync(userToUpdate);

            }

            using (var context = new UserDB(options))
            {
                User user = await context.User.FirstOrDefaultAsync(u => u.Id == 4);

                Assert.NotNull(user);
                Assert.NotEqual("Test4", user.Username);
                Assert.Equal("TestUpdate", user.Username);

            }

        }

        [Fact]
        public async void GetUserByIdShouldGetAUser()
        {
            using (var context = new UserDB(options))
            {
                IRepo repo = new DBRepo(context);

                User userToGet = new User()
                {
                    Id = 1,
                    Username = "Test"
                };

                repo.GetUserByIdAsync(1);
            }

            using (var context = new UserDB(options))
            {
                User user = await context.User.FirstOrDefaultAsync(u => u.Id == 1);
                Assert.NotNull(user);
                Assert.Equal("Test", user.Username);
            }

        }

        public void Seed()
        {
            using (var context = new UserDB(options))
            {
                //first, we are going to make sure
                //that the DB is in clean slate
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.User.AddRange(
                    new User()
                    {
                        Id = 1,
                        Username = "Test"
                    },
                    new User()
                    {
                        Id = 2,
                        Username = "Test2"
                    });
                context.SaveChanges();
                context.ChangeTracker.Clear();
            }
        }

    }
}
