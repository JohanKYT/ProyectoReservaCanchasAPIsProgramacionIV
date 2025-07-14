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
        public async Task<ActionResult<IEnumerable<AdministradorDTO>>> GetAdministradores()
        {
            var lista = await _context.Administrador.ToListAsync();

            var listaDTO = lista.Select(a => new AdministradorDTO
            {
                BannerId = a.BannerId,
                Nombre = a.Nombre,
                Correo = a.Correo,
                Password = a.Password,
                Telefono = a.Telefono,
                Direccion = a.Direccion,
                FechaNacimiento = a.FechaNacimiento,
                FacultadId = a.FacultadId
            }).ToList();

            return Ok(listaDTO);
        }

        // GET: api/Administrador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorDTO>> GetAdministrador(int id)
        {
            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
                return NotFound();

            var dto = new AdministradorDTO
            {
                BannerId = admin.BannerId,
                Nombre = admin.Nombre,
                Correo = admin.Correo,
                Password = admin.Password,
                Telefono = admin.Telefono,
                Direccion = admin.Direccion,
                FechaNacimiento = admin.FechaNacimiento,
                FacultadId = admin.FacultadId
            };

            return Ok(dto);
        }

        // POST: api/Administrador
        [HttpPost]
        public async Task<ActionResult<AdministradorDTO>> PostAdministrador(AdministradorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var admin = new Administrador
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Password = dto.Password,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                FechaNacimiento = dto.FechaNacimiento,
                TipoPersona = "Administrador",
                FacultadId = dto.FacultadId
            };

            _context.Administrador.Add(admin);
            await _context.SaveChangesAsync();

            dto.BannerId = admin.BannerId; // Actualizar id generado

            return CreatedAtAction(nameof(GetAdministrador), new { id = admin.BannerId }, dto);
        }

        // PUT: api/Administrador/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, AdministradorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.BannerId)
                return BadRequest();

            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
                return NotFound();

            admin.Nombre = dto.Nombre;
            admin.Correo = dto.Correo;
            admin.Password = dto.Password;
            admin.Telefono = dto.Telefono;
            admin.Direccion = dto.Direccion;
            admin.FechaNacimiento = dto.FechaNacimiento;
            admin.TipoPersona = "Administrador";
            admin.FacultadId = dto.FacultadId;

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
            var admin = await _context.Administrador.FindAsync(id);
            if (admin == null)
                return NotFound();

            _context.Administrador.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.BannerId == id);
        }
    }
}