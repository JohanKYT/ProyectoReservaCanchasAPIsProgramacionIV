using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplementosController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public ImplementosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Implemento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Implemento>>> GetImplementos()
        {
            return await _context.Implemento.ToListAsync();
        }

        // GET: api/Implemento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Implemento>> GetImplemento(int id)
        {
            var item = await _context.Implemento.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Implemento
        [HttpPost]
        public async Task<ActionResult<Implemento>> PostImplemento(Implemento item)
        {
            _context.Implemento.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetImplemento), new { id = item.Id }, item);
        }

        // PUT: api/Implemento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImplemento(int id, Implemento item)
        {
            if (id != item.Id)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImplementoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Implemento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImplemento(int id)
        {
            var item = await _context.Implemento.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Implemento.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImplementoExists(int id)
        {
            return _context.Implemento.Any(e => e.Id == id);
        }
    }
}
