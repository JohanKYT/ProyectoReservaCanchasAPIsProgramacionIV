using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public ReservasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            return await _context.Reserva.ToListAsync();
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var item = await _context.Reserva.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva item)
        {
            _context.Reserva.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReserva), new { id = item.ReservaId }, item);
        }

        // PUT: api/Reserva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva item)
        {
            if (id != item.ReservaId)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var item = await _context.Reserva.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Reserva.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.ReservaId == id);
        }
    }
}