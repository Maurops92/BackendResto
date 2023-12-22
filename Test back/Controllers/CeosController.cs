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
    public class CeosController : ControllerBase
    {
        private readonly RestocrudContext _context;

        public CeosController(RestocrudContext context)
        {
            _context = context;
        }

        // GET: api/Ceos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ceo>>> GetCeos()
        {
            return await _context.Ceos.ToListAsync();
        }

        // GET: api/Ceos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ceo>> GetCeo(int id)
        {
            var ceo = await _context.Ceos.FindAsync(id);

            if (ceo == null)
            {
                return NotFound();
            }

            return ceo;
        }

        // PUT: api/Ceos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCeo(int id, Ceo ceo)
        {
            if (id != ceo.Ceoid)
            {
                return BadRequest();
            }

            _context.Entry(ceo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CeoExists(id))
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

        // POST: api/Ceos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ceo>> PostCeo(Ceo ceo)
        {
            _context.Ceos.Add(ceo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CeoExists(ceo.Ceoid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCeo", new { id = ceo.Ceoid }, ceo);
        }

        // DELETE: api/Ceos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCeo(int id)
        {
            var ceo = await _context.Ceos.FindAsync(id);
            if (ceo == null)
            {
                return NotFound();
            }

            _context.Ceos.Remove(ceo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CeoExists(int id)
        {
            return _context.Ceos.Any(e => e.Ceoid == id);
        }
    }
}
