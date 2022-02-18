using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

/*
Id
CreatedByUserId
GroupName
Message
Date
*/
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IBL _bl;
        public GroupController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<GroupController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Group> allGroup = await _bl.GetAllGroupsAsync();
            if (allGroup != null)
            {
                return Ok(allGroup);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<GroupController>/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Group foundGroup = await _bl.GetGroupByIdAsync(id);
            if (foundGroup != null)
            {
                return Ok(foundGroup);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<GroupController>
        [HttpGet("search/{term}")]
        public async Task<List<Group>> Search(string searchTerm)
        {
            return await _bl.GetGroupsByGroupNameAsync(searchTerm);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Group newGroup)
        {
            Group addedGroup = (Group)await _bl.AddObjectAsync(newGroup);
            return Created("api/[controller]", addedGroup);
        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Group updateGroup)
        {
            await _bl.UpdateObjectAsync(updateGroup);
            return Ok(updateGroup);
        }

        // DELETE api/<GroupController>/5
        [HttpDelete("DeleteGroup/{id}")] // Waiting for DevOps Approval for migration
        public async Task<IActionResult> Delete(int groupId) //delete by groupId
        {
            Group deleteGroup = await _bl.GetGroupByIdAsync(groupId);
            await _bl.DeleteObjectAsync(groupId);
            return Ok(groupId);
        }
    }
}
