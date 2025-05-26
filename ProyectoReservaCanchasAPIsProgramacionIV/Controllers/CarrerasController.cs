using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CarrerasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Carrera
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
        {
            return await _context.Carrera.ToListAsync();
        }

        // GET: api/Carrera/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(int id)
        {
            var item = await _context.Carrera.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Carrera
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera item)
        {
            _context.Carrera.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCarrera), new { id = item.Id }, item);
        }

        // PUT: api/Carrera/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, Carrera item)
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
                if (!CarreraExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Carrera/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            var item = await _context.Carrera.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Carrera.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.Id == id);
        }
    }
}

