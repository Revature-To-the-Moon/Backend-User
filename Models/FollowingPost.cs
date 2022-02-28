using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class FollowingPost
    {

        public int Id {get; set;}
        
        public string Postname {get; set;}

        public int RootId { get; set; }

        public int UserId { get; set; }
    }
}