using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaImplementosController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public ReservaImplementosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/ReservaImplemento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaImplemento>>> GetReservaImplementos()
        {
            return await _context.ReservaImplemento.ToListAsync();
        }

        // GET: api/ReservaImplemento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaImplemento>> GetReservaImplemento(int id)
        {
            var item = await _context.ReservaImplemento.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/ReservaImplemento
        [HttpPost]
        public async Task<ActionResult<ReservaImplemento>> PostReservaImplemento(ReservaImplemento item)
        {
            _context.ReservaImplemento.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservaImplemento), new { id = item.Id }, item);
        }

        // PUT: api/ReservaImplemento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaImplemento(int id, ReservaImplemento item)
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
                if (!ReservaImplementoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/ReservaImplemento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaImplemento(int id)
        {
            var item = await _context.ReservaImplemento.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.ReservaImplemento.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaImplementoExists(int id)
        {
            return _context.ReservaImplemento.Any(e => e.Id == id);
        }
    }
}
