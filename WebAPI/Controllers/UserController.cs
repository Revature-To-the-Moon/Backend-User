using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BL;


namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBL _bl;
        public UserController(IBL bl)
        {
            _bl = bl;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> allUsers = await _bl.GetAllUsersAsync();
            if (allUsers != null)
            {
                return Ok(allUsers);
            }
            else
            {
                return NoContent();
            }
        }

   
        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            User foundUser = await _bl.GetUserByIdAsync(id);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> Get(string username)
        {
            User foundUser = await _bl.GetUserByNameAsync(username);
            if (foundUser != null)
            {
                return Ok(foundUser);
            }
            else
            {
                return NoContent();
            }
        }
   
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User newUser)
        {
            User addedUser = (User)await _bl.AddObjectAsync(newUser);
            return Created("api/[controller]", addedUser);
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User updateUser)
        {
            await _bl.UpdateObjectAsync(updateUser);
            return Ok(updateUser);
        }

 
        [HttpDelete("id/{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            User deleteUser = await _bl.GetUserByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteUser);
            return Ok(deleteUser);
        }

        [HttpDelete("username/{Username}")]
        public async Task<IActionResult> Delete(string username)
        {
            User deleteUser = await _bl.GetUserByNameAsync(username);
            await _bl.DeleteObjectAsync(deleteUser);
            return Ok(deleteUser);
        }
    }
}
