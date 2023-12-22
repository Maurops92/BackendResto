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
    public class DetalleVentumsController : ControllerBase
    {
        private readonly RestocrudContext _context;

        public DetalleVentumsController(RestocrudContext context)
        {
            _context = context;
        }

        // GET: api/DetalleVentums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleVentum>>> GetDetalleVenta()
        {
            return await _context.DetalleVenta.ToListAsync();
        }

        // GET: api/DetalleVentums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleVentum>> GetDetalleVentum(int id)
        {
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);

            if (detalleVentum == null)
            {
                return NotFound();
            }

            return detalleVentum;
        }

        // PUT: api/DetalleVentums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleVentum(int id, DetalleVentum detalleVentum)
        {
            if (id != detalleVentum.VentaId)
            {
                return BadRequest();
            }

            _context.Entry(detalleVentum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentumExists(id))
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

        // POST: api/DetalleVentums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleVentum>> PostDetalleVentum(DetalleVentum detalleVentum)
        {
            _context.DetalleVenta.Add(detalleVentum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetalleVentumExists(detalleVentum.VentaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalleVentum", new { id = detalleVentum.VentaId }, detalleVentum);
        }

        // DELETE: api/DetalleVentums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleVentum(int id)
        {
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            _context.DetalleVenta.Remove(detalleVentum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleVentumExists(int id)
        {
            return _context.DetalleVenta.Any(e => e.VentaId == id);
        }
    }
}
