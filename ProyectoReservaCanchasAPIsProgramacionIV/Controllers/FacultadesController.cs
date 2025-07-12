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
    public class FacultadesController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public FacultadesController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Facultad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultadDTO>>> GetFacultades()
        {
            var facultades = await _context.Facultad
        .Include(f => f.Campus) // Asegura que incluya el campus relacionado
        .ToListAsync();

            var listaDTO = facultades.Select(f => new FacultadDTO
            {
                FacultadId = f.FacultadId,
                Nombre = f.Nombre,
                CampusId = f.CampusId,
                Campus = f.Campus == null ? null : new CampusDTO
                {
                    CampusId = f.Campus.CampusId,
                    Nombre = f.Campus.Nombre,
                    Direccion = f.Campus.Direccion
                }
            }).ToList();

            return Ok(listaDTO);
        }

        // GET: api/Facultad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultadDTO>> GetFacultad(int id)
        {
            var f = await _context.Facultad
                .Include(fa => fa.Campus)
                .FirstOrDefaultAsync(fa => fa.FacultadId == id);

            if (f == null)
                return NotFound();

            var dto = new FacultadDTO
            {
                FacultadId = f.FacultadId,
                Nombre = f.Nombre,
                CampusId = f.CampusId
            };

            return Ok(dto);
        }

        // POST: api/Facultad
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(FacultadDTO dto)
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

        // PUT: api/Facultad/5
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

        // DELETE: api/Facultad/5
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

        private bool FacultadExists(int id)
        {
            return _context.Facultad.Any(e => e.FacultadId == id);
        }
    }
}