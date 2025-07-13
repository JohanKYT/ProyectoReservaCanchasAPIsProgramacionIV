using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.DTOs;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;
using System;

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

        // GET: api/PersonalMantenimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalMantenimiento>>> GetPersonalMantenimientos()
        {
            return await _context.PersonalMantenimiento.ToListAsync();
        }

        // GET: api/PersonalMantenimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalMantenimiento>> GetPersonalMantenimiento(int id)
        {
            var item = await _context.PersonalMantenimiento.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/PersonalMantenimientos
        [HttpPost]
        public async Task<ActionResult<PersonalMantenimiento>> PostPersonalMantenimiento(PersonalMantenimientoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = new PersonalMantenimiento
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = dto.Password,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                FechaNacimiento = dto.FechaNacimiento,
                TipoPersona = "PersonalMantenimiento"
            };

            _context.PersonalMantenimiento.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalMantenimiento), new { id = item.BannerId }, item);
        }

        // PUT: api/PersonalMantenimientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalMantenimiento(int id, PersonalMantenimientoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var personal = await _context.PersonalMantenimiento.FindAsync(id);

            if (personal == null)
                return NotFound();

            personal.Nombre = dto.Nombre;
            personal.Correo = dto.Correo;
            personal.Password = dto.Password;
            personal.Telefono = dto.Telefono;
            personal.Direccion = dto.Direccion;
            personal.FechaNacimiento = dto.FechaNacimiento;
            personal.TipoPersona = "PersonalMantenimiento";

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PersonalMantenimiento.Any(e => e.BannerId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/PersonalMantenimientos/5
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

