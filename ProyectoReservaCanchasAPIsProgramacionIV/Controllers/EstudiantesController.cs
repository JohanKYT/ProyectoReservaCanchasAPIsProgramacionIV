using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public EstudiantesController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Estudiante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiante.ToListAsync();
        }

        // GET: api/Estudiante/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var item = await _context.Estudiante.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Estudiante
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante item)
        {
            _context.Estudiante.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstudiante), new { id = item.BannerId }, item);
        }

        // PUT: api/Estudiante/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante item)
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
                if (!EstudianteExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Estudiante/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var item = await _context.Estudiante.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Estudiante.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiante.Any(e => e.BannerId == id);
        }
    }
}

