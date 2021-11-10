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
    public class FollowingControllerHiSia : ControllerBase
    {
        private readonly IBL _bl;
        public FollowingControllerHiSia(IBL bl)
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
        public async Task<IActionResult> GetFollowingByUserId(int userid)
        {
            List<Following> userFollowing= await _bl.GetFollowingByFollowerUserIdAsync(userid);
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
        public async Task<IActionResult> GetFollowerByUserId(int userid)
        {
            List<Following> userFollower = await _bl.GetFollowerByUserIdAsync(userid);
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
    }
}