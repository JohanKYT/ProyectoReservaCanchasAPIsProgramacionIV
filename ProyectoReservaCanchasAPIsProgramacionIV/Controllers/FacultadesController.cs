using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.DTOs;
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

        // GET: api/Facultades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultadDTO>>> GetFacultades()
        {
            var lista = await _context.Facultad.ToListAsync();

            var listaDTO = lista.Select(f => new FacultadDTO
            {
                FacultadId = f.FacultadId,
                Nombre = f.Nombre,
                CampusId = f.CampusId
            }).ToList();

            return Ok(listaDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultadDTO>> GetFacultad(int id)
        {
            var facultad = await _context.Facultad.FindAsync(id);

            if (facultad == null)
                return NotFound();

            var dto = new FacultadDTO
            {
                FacultadId = facultad.FacultadId,
                Nombre = facultad.Nombre,
                CampusId = facultad.CampusId
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<FacultadDTO>> PostFacultad(FacultadDTO dto)
        {
            var facultad = new Facultad
            {
                Nombre = dto.Nombre,
                CampusId = dto.CampusId
            };

            _context.Facultad.Add(facultad);
            await _context.SaveChangesAsync();

            dto.FacultadId = facultad.FacultadId;

            return CreatedAtAction(nameof(GetFacultad), new { id = facultad.FacultadId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacultad(int id, FacultadDTO dto)
        {
            if (id != dto.FacultadId)
                return BadRequest();

            var facultad = await _context.Facultad.FindAsync(id);
            if (facultad == null)
                return NotFound();

            facultad.Nombre = dto.Nombre;
            facultad.CampusId = dto.CampusId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacultad(int id)
        {
            var facultad = await _context.Facultad.FindAsync(id);
            if (facultad == null)
                return NotFound();

            _context.Facultad.Remove(facultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
