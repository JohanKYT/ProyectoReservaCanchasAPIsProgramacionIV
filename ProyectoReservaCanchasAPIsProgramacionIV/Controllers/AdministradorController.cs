using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.DTOs;
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
            return await _context.Administrador
                .Include(a => a.Facultad)
                .ThenInclude(f => f.Campus)
                .ToListAsync();
        }

        // GET: api/Administrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Administrador>> GetAdministrador(int id)
        {
            var item = await _context.Administrador
                .Include(a => a.Facultad)
                .ThenInclude(f => f.Campus)
                .FirstOrDefaultAsync(a => a.BannerId == id);

            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Administrador
        [HttpPost]
        public async Task<ActionResult<Administrador>> PostAdministrador(AdministradorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = new Administrador
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = dto.Password,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                FechaNacimiento = dto.FechaNacimiento,
                TipoPersona = "Administrador", // Asignar un tipo de persona por defecto
                FacultadId = dto.FacultadId
            };

            _context.Administrador.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAdministrador), new { id = item.BannerId }, item);
        }

        // PUT: api/Administrador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, AdministradorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var administrador = await _context.Administrador.FindAsync(id);

            if (administrador == null)
                return NotFound();

            // Actualizar solo las propiedades necesarias
            administrador.Nombre = dto.Nombre;
            administrador.Correo = dto.Correo;
            administrador.Password = dto.Password;
            administrador.Telefono = dto.Telefono;
            administrador.Direccion = dto.Direccion;
            administrador.FechaNacimiento = dto.FechaNacimiento;
            administrador.TipoPersona = "Administrador"; // Asignar un tipo de persona por defecto
            administrador.FacultadId = dto.FacultadId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Administrador.Any(e => e.BannerId == id))
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
