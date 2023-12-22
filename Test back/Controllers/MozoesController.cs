using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_back.Modelos;

namespace Test_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MozoesController : ControllerBase
    {
        private readonly RestocrudContext _context;

        public MozoesController(RestocrudContext context)
        {
            _context = context;
        }

        // GET: api/Mozoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mozo>>> GetMozos()
        {
            return await _context.Mozos.ToListAsync();
        }

        // GET: api/Mozoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mozo>> GetMozo(int id)
        {
            var mozo = await _context.Mozos.FindAsync(id);

            if (mozo == null)
            {
                return NotFound();
            }

            return mozo;
        }

        // PUT: api/Mozoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMozo(int id, Mozo mozo)
        {
            if (id != mozo.MozoId)
            {
                return BadRequest();
            }

            _context.Entry(mozo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MozoExists(id))
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

        // POST: api/Mozoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mozo>> PostMozo(Mozo mozo)
        {
            _context.Mozos.Add(mozo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MozoExists(mozo.MozoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMozo", new { id = mozo.MozoId }, mozo);
        }

        // DELETE: api/Mozoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMozo(int id)
        {
            var mozo = await _context.Mozos.FindAsync(id);
            if (mozo == null)
            {
                return NotFound();
            }

            _context.Mozos.Remove(mozo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MozoExists(int id)
        {
            return _context.Mozos.Any(e => e.MozoId == id);
        }
    }
}
