using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CanchasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Cancha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancha>>> GetCanchas()
        {
            return await _context.Cancha.ToListAsync();
        }

        // GET: api/Cancha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancha>> GetCancha(int id)
        {
            var item = await _context.Cancha.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Cancha
        [HttpPost]
        public async Task<ActionResult<Cancha>> PostCancha(Cancha item)
        {
            _context.Cancha.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCancha), new { id = item.CanchaId }, item);
        }

        // PUT: api/Cancha/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancha(int id, Cancha item)
        {
            if (id != item.CanchaId)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CanchaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Cancha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var item = await _context.Cancha.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Cancha.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanchaExists(int id)
        {
            return _context.Cancha.Any(e => e.CanchaId == id);
        }
    }
}

