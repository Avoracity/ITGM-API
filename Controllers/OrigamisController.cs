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
    public class OrigamisController : ControllerBase
    {
        private readonly IntrogamiAPIDBContext _context;

        public OrigamisController(IntrogamiAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Origamis
        [HttpGet]
        public async Task<ActionResult<Response>> GetOrigamis()
        {
            var origami = await _context.Origamis.ToListAsync();
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (origami != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.OrigamiResponse = origami;
            }

            return response;
        }

        // GET: api/Origamis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetOrigami(int id)
        {
            var origami = await _context.Origamis.FindAsync(id);
            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error retrieving ID"
            };

            if (origami != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID Retrieval successful";
                response.OrigamiResponse = new();
                response.OrigamiResponse.Add(origami);
            }

            return response;
        }


        /*
        // POST: api/Origamis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostOrigami(Origami origami)
        {
            
            _context.Origamis.Add(origami);
            await _context.SaveChangesAsync();


            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error posting ID"
            };

            var origami = CreatedAtAction("GetOrigami", new { id = origami.OrigamiId }, origami);

            if (origami != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID posting successful";
            }

            return response;
        }
        */

        // DELETE: api/Origamis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteOrigami(int id)
        {
            var origami = await _context.Origamis.FindAsync(id);

            Response response = new()
            {
                StatusCode = 400,
                StatusDesc = "Error deleting ID"
            };

            if (origami != null)
            {
                response.StatusCode = 200;
                response.StatusDesc = "ID deletion successful";

                _context.Origamis.Remove(origami);
                await _context.SaveChangesAsync();
            }
            return response;
        }

   
    }
}
