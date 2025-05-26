using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendariosController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CalendariosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Calendario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calendario>>> GetCalendarios()
        {
            return await _context.Calendario.ToListAsync();
        }

        // GET: api/Calendario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calendario>> GetCalendario(int id)
        {
            var item = await _context.Calendario.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Calendario
        [HttpPost]
        public async Task<ActionResult<Calendario>> PostCalendario(Calendario item)
        {
            _context.Calendario.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCalendario), new { id = item.CalendarioId }, item);
        }

        // PUT: api/Calendario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendario(int id, Calendario item)
        {
            if (id != item.CalendarioId)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Calendario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendario(int id)
        {
            var item = await _context.Calendario.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Calendario.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarioExists(int id)
        {
            return _context.Calendario.Any(e => e.CalendarioId == id);
        }
    }
}
