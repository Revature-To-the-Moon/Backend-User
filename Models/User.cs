using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
       // [RegularExpression("^[a-zA-Z0-9 !?']+$")]
        public string Username { get; set; }

        public List<FollowingPost> FollowingPosts { get; set; } //Get what posts are being followed

        public override string ToString()
        {
            return $"Username: {this.Username} Following {FollowingPosts.Count} Posts";
        }

        public List<Following> Followings { get; set; } //Get what users are being followed
        
        public List<GroupMembers> GroupsJoined { get; set; } //Get what groups are being followed
    }
}

//User > Following > User
//User > FollowingPost > Post(Root)
//User > GroupMembers > Group