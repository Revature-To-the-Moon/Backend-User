using Microsoft.EntityFrameworkCore;
using Models;


namespace DL
{
    public class UserDB : DbContext
    {
        public UserDB() : base() { }

        public UserDB(DbContextOptions options) : base(options) { }
    }
}