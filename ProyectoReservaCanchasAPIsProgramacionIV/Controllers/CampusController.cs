using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampusController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CampusController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Campus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campus>>> GetCampuss()
        {
            return await _context.Campus.ToListAsync();
        }

        // GET: api/Campus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campus>> GetCampus(int id)
        {
            var item = await _context.Campus.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Campus
        [HttpPost]
        public async Task<ActionResult<Campus>> PostCampus(Campus item)
        {
            _context.Campus.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCampus), new { id = item.Id }, item);
        }

        // PUT: api/Campus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampus(int id, Campus item)
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
                if (!CampusExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Campus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampus(int id)
        {
            var item = await _context.Campus.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Campus.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampusExists(int id)
        {
            return _context.Campus.Any(e => e.Id == id);
        }
    }
}

