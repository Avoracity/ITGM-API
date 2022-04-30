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
        public async Task<ActionResult<IEnumerable<Origami>>> GetOrigamis()
        {
            return await _context.Origamis.ToListAsync();
        }

        // GET: api/Origamis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Origami>> GetOrigami(int id)
        {
            var origami = await _context.Origamis.FindAsync(id);

            if (origami == null)
            {
                return NotFound();
            }

            return origami;
        }

        // PUT: api/Origamis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigami(int id, Origami origami)
        {
            if (id != origami.OrigamiId)
            {
                return BadRequest();
            }

            _context.Entry(origami).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigamiExists(id))
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

        // POST: api/Origamis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Origami>> PostOrigami(Origami origami)
        {
            _context.Origamis.Add(origami);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrigami", new { id = origami.OrigamiId }, origami);
        }

        // DELETE: api/Origamis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigami(int id)
        {
            var origami = await _context.Origamis.FindAsync(id);
            if (origami == null)
            {
                return NotFound();
            }

            _context.Origamis.Remove(origami);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigamiExists(int id)
        {
            return _context.Origamis.Any(e => e.OrigamiId == id);
        }
    }
}
