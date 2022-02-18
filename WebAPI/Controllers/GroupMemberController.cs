using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMemberController : ControllerBase
    {
        private readonly IBL _bl;

        public GroupMemberController(IBL bl)
        {
            _bl = bl;
        }

        // // GET: api/<GroupMemberController>
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET api/<GroupMemberController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int userId)
        {
            List<GroupMembers> foundGroup = await _bl.GetGroupsByUserIdAsync(userId);
            if (foundGroup != null)
            {
                return Ok(foundGroup);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<GroupMemberController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupMembers newGroupMember)
        {
            GroupMembers addedGroupMember = (GroupMembers)await _bl.AddObjectAsync(newGroupMember);
            return Created("api/[controller]", addedGroupMember);
        }

        //We don't really need this
        // PUT api/<GroupMemberController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] GroupMembers updateGroupMembers)
        {
            await _bl.UpdateObjectAsync(updateGroupMembers);
            return Ok(updateGroupMembers);
        }

        // DELETE api/<GroupMemberController>/5
        [HttpDelete("DeleteGroup/{id}")] // Waiting for DevOps Approval for migration
        public async Task<IActionResult> Delete(int memberUserId, int groupId) //delete by groupId
        {
            //GroupMembers deleteGroup = await _bl.GetGroupsByUserIdAsync(memberUserId);
            await _bl.RemoveMemberFromGroupAsync(memberUserId, groupId);
            return Ok(memberUserId);
        }
    }
}
