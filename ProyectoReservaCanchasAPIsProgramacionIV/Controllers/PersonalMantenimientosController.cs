using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalMantenimientosController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public PersonalMantenimientosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/PersonalMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalMantenimiento>>> GetPersonalMantenimientos()
        {
            return await _context.PersonalMantenimiento.ToListAsync();
        }

        // GET: api/PersonalMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalMantenimiento>> GetPersonalMantenimiento(int id)
        {
            var item = await _context.PersonalMantenimiento.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/PersonalMantenimiento
        [HttpPost]
        public async Task<ActionResult<PersonalMantenimiento>> PostPersonalMantenimiento(PersonalMantenimiento item)
        {
            _context.PersonalMantenimiento.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPersonalMantenimiento), new { id = item.BannerId }, item);
        }

        // PUT: api/PersonalMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalMantenimiento(int id, PersonalMantenimiento item)
        {
            if (id != item.BannerId)
                return BadRequest();

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalMantenimientoExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/PersonalMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalMantenimiento(int id)
        {
            var item = await _context.PersonalMantenimiento.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.PersonalMantenimiento.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalMantenimientoExists(int id)
        {
            return _context.PersonalMantenimiento.Any(e => e.BannerId == id);
        }
    }
}

