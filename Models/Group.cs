using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models;
public class Group
{
    public Group(){}
    
    public int Id { get; set; } //fyi GroupId

    public int CreatedByUserId { get; set; } //Made Group

    [Required]
    public string GroupName { get; set; } //Name of group

    public string Message { get; set; } //Description of group

    public DateTime Date { get; set; } //When group was made

    //public List<GroupMembers> UsersJoined { get; set; }


}