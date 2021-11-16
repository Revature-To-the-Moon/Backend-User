using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

namespace WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowingController : ControllerBase
    {
        private readonly IBL _bl;
        public FollowingController(IBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Following> allFollowing = await _bl.GetAllFollowingAsync();
            if (allFollowing != null)
            {
                return Ok(allFollowing);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("followinguserid/{followinguserid}")]
        public async Task<IActionResult> GetFollowingByUserId(int followinguserid)
        {
            List<Following> userFollowing= await _bl.GetFollowerByUserIdAsync(followinguserid); 
            if (userFollowing != null)
            {
                return Ok(userFollowing);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("followeruserid/{followeruserid}")]
        public async Task<IActionResult> GetFollowerByUserId(int followeruserid)
        {
            List<Following> userFollower = await _bl.GetFollowingByFollowerUserIdAsync(followeruserid);
            if (userFollower != null)
            {
                return Ok(userFollower);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Following following= await _bl.GetFollowingByIdAsync(id);
            if (following != null)
            {
                return Ok(following);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Following newFollowing)
        {
            Following addedFollowing = (Following)await _bl.AddObjectAsync(newFollowing);
            return Created("api/[controller]", addedFollowing);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Following deleteFollowing = await _bl.GetFollowingByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteFollowing);
            return Ok(deleteFollowing);
        }
    }
}