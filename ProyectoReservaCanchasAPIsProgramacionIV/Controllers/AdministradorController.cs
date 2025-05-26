using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public AdministradorController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Administrador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Administrador>>> GetAdministradors()
        {
            return await _context.Administrador.ToListAsync();
        }

        // GET: api/Administrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var item = await _context.Administrador.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Administrador
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(Administrador item)
        {
            _context.Administrador.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAdministrador), new { id = item.BannerId }, item);
        }

        // PUT: api/Administrador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, Administrador item)
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
                if (!AdministradorExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Administrador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            var item = await _context.Administrador.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Administrador.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.BannerId == id);
        }
    }
}
