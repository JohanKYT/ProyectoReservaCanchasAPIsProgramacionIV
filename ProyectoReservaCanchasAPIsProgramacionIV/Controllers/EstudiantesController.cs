using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;
using ProyectoReservaCanchasAPIsProgramacionIV.DTOs;

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

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            return await _context.Estudiante
                .Include(e => e.Carrera)
                .ThenInclude(c => c.Facultad)
                .ThenInclude(f => f.Campus)
                .ToListAsync();
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var item = await _context.Estudiante
                .Include(e => e.Carrera)
                .ThenInclude(c => c.Facultad)
                .ThenInclude(f => f.Campus)
                .FirstOrDefaultAsync(e => e.BannerId == id);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(EstudianteDTO dto)
        {
            var item = new Estudiante
            {
                BannerId = dto.BannerId,
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = dto.Password,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                FechaNacimiento = dto.FechaNacimiento,
                TipoPersona = dto.TipoPersona,
                CarreraId = dto.CarreraId
            };

            _context.Estudiante.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), new { id = item.BannerId }, item);
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, EstudianteDTO dto)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);

            if (estudiante == null)
                return NotFound();

            estudiante.Nombre = dto.Nombre;
            estudiante.Correo = dto.Correo;
            estudiante.Password = dto.Password;
            estudiante.Telefono = dto.Telefono;
            estudiante.Direccion = dto.Direccion;
            estudiante.FechaNacimiento = dto.FechaNacimiento;
            estudiante.TipoPersona = dto.TipoPersona;
            estudiante.CarreraId = dto.CarreraId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Estudiante.Any(e => e.BannerId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Estudiantes/5
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
    }
}

