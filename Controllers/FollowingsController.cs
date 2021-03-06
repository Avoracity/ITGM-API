#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IntrogamiAPI.Models;

namespace IntrogamiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowingsController : ControllerBase
    {
        private readonly IntrogamiAPIDBContext _context;

        public FollowingsController(IntrogamiAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Followings
        [HttpGet]
        public async Task<ActionResult<Response>> GetFollowings()
        {
            var following = await _context.Followings.ToListAsync();
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (following != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.FollowingResponse = following;
            }

            return response;
        }

        // GET: api/Followings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetFollowing(int id)
        {

            var following = await _context.Followings.FindAsync(id);
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (following != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.FollowingResponse = new();
                response.FollowingResponse.Add(following);
            }

            return response;
        }

        // PUT: api/Followings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollowing(int id, Following following)
        {
            if (id != following.FollowingId)
            {
                return BadRequest();
            }

            _context.Entry(following).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





        private bool FollowingExists(int id)
        {
            return _context.Followings.Any(e => e.FollowingId == id);
        }
    }
}
