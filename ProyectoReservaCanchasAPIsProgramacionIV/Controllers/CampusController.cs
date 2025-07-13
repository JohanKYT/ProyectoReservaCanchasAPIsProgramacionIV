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
    public class CampusController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CampusController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Campus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampusDTO>>> GetCampuss()
        {
            var campusList = await _context.Campus.ToListAsync();

            var listDTO = campusList.Select(c => new CampusDTO
            {
                CampusId = c.CampusId,
                Nombre = c.Nombre,
                Direccion = c.Direccion
            }).ToList();

            return Ok(listDTO);
        }

        // GET: api/Campus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampusDTO>> GetCampus(int id)
        {
            var campus = await _context.Campus.FindAsync(id);
            if (campus == null)
                return NotFound();

            var dto = new CampusDTO
            {
                CampusId = campus.CampusId,
                Nombre = campus.Nombre,
                Direccion = campus.Direccion
            };

            return Ok(dto);
        }

        // POST: api/Campus
        [HttpPost]
        public async Task<ActionResult<Campus>> PostCampus(CampusDTO dto)
        {
            var campus = new Campus
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion
            };

            _context.Campus.Add(campus);
            await _context.SaveChangesAsync();

            dto.CampusId = campus.CampusId;

            return CreatedAtAction(nameof(GetCampus), new { id = campus.CampusId }, dto);
        }

        // PUT: api/Campus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampus(int id, CampusDTO dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != dto.CampusId)
                return BadRequest();

            var campus = await _context.Campus.FindAsync(id);
            if (campus == null)
                return NotFound();

            campus.Nombre = dto.Nombre;
            campus.Direccion = dto.Direccion;

            await _context.SaveChangesAsync();

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
            return _context.Campus.Any(e => e.CampusId == id);
        }
    }
}

