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
    public class UsersController : ControllerBase
    {
        private readonly IntrogamiAPIDBContext _context;

        public UsersController(IntrogamiAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<Response>> GetUsers()
        {
            var username = await _context.Users.ToListAsync();
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (username != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.UserResponse = username;
            }

            return response;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetUser(int id)
        {
            var username = await _context.Users.FindAsync(id);
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (username != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.UserResponse = new();
                response.UserResponse.Add(username);
            }

            return response;

        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();


            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error posting ID"
            };

            var username = CreatedAtAction("GetUser", new { id = user.UserId }, user);

            if (username != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID posting successful";
            }

            return response;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error deleting ID"
            };

            if (user != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID deletion successful";

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return response;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}