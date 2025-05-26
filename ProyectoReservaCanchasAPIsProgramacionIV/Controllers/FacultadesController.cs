using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadesController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public FacultadesController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Facultad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultads()
        {
            return await _context.Facultad.ToListAsync();
        }

        // GET: api/Facultad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
            var item = await _context.Facultad.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Facultad
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad item)
        {
            _context.Facultad.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFacultad), new { id = item.Id }, item);
        }

        // PUT: api/Facultad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultad(int id, Facultad item)
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
                if (!FacultadExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Facultad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultad(int id)
        {
            var item = await _context.Facultad.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Facultad.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacultadExists(int id)
        {
            return _context.Facultad.Any(e => e.Id == id);
        }
    }
}
