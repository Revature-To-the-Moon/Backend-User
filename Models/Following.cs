using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Following
    {
        public int Id {get; set;}

        public int FollowerUserId { get; set; }

       // public int UserId { get; set; }

        public int FollowingUserId { get; set; }

        public string FollowingUserName{ get; set;}
    }
}