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
    public class FollowingPostController : ControllerBase
    {
        private readonly IBL _bl;
        public FollowingPostController(IBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<FollowingPost> allFollowingPosts = await _bl.GetFollowingPostsAsync();
            if (allFollowingPosts != null)
            {
                return Ok(allFollowingPosts);
            }
            else
            {
                return NoContent();
            }
        }

 
        /// <summary>
        /// 
        /// get all the following post of a user
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet("userid/{userid}")]
        public async Task<IActionResult> GetByUserid(int userid)
        {
            List<FollowingPost> userFollowingPosts = await _bl.GetFollowingPostByUserIdAsync(userid);
            if (userFollowingPosts != null)
            {
                return Ok(userFollowingPosts);
            }
            else
            {
                return NoContent();
            }
        }

         [HttpGet("id/{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            FollowingPost userFollowingPost = await _bl.GetFollowingPostByIdAsync(id);
            if (userFollowingPost != null)
            {
                return Ok(userFollowingPost);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("postname/{postname}")]
        public async Task<IActionResult> GetByPostname(string postname)
        {
            FollowingPost followingPost = await _bl.GetFollowingPostByPostnameAsync(postname);
            if (followingPost != null)
            {
                return Ok(followingPost);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("rootid/{rootid}")]
        public async Task<IActionResult> GetByRootid(int rootid)
        {
            FollowingPost followingPost = await _bl.GetFollowingPostByRootIdAsync(rootid);
            if (followingPost != null)
            {
                return Ok(followingPost);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FollowingPost followingPost)
        {
            FollowingPost addedFollowingPost = (FollowingPost)await _bl.AddObjectAsync(followingPost);
            return Created("api/[controller]", addedFollowingPost);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] FollowingPost followingPost)
        {
            await _bl.UpdateObjectAsync(followingPost);
            return Ok(followingPost);
        }

      
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            FollowingPost deleteFollowingPost = await _bl.GetFollowingPostByIdAsync(id);
            await _bl.DeleteObjectAsync(deleteFollowingPost);
            return Ok(deleteFollowingPost);
        }

    }
}
