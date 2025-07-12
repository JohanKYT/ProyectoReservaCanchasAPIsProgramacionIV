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
    public class CanchasController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CanchasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Canchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CanchaDTO>>> GetCanchas()
        {
            var canchas = await _context.Cancha
                .Include(c => c.Campus)
                .ToListAsync();

            var listaDTO = canchas.Select(c => new CanchaDTO
            {
                CanchaId = c.CanchaId,
                Nombre = c.Nombre,
                Tipo = c.Tipo,
                Disponible = c.Disponible,
                CampusId = c.CampusId,
                Campus = c.Campus == null ? null : new CampusDTO
                {
                    CampusId = c.Campus.CampusId,
                    Nombre = c.Campus.Nombre,
                    Direccion = c.Campus.Direccion
                }
            }).ToList();

            return Ok(listaDTO);
        }

        // GET: api/Canchas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CanchaDTO>> GetCancha(int id)
        {
            var cancha = await _context.Cancha
                .Include(c => c.Campus)
                .FirstOrDefaultAsync(c => c.CanchaId == id);

            if (cancha == null)
                return NotFound();

            var dto = new CanchaDTO
            {
                CanchaId = cancha.CanchaId,
                Nombre = cancha.Nombre,
                Tipo = cancha.Tipo,
                Disponible = cancha.Disponible,
                CampusId = cancha.CampusId,
                Campus = cancha.Campus == null ? null : new CampusDTO
                {
                    CampusId = cancha.Campus.CampusId,
                    Nombre = cancha.Campus.Nombre,
                    Direccion = cancha.Campus.Direccion
                }
            };

            return Ok(dto);
        }

        // POST: api/Canchas
        [HttpPost]
        public async Task<ActionResult<CanchaDTO>> PostCancha(CanchaDTO dto)
        {
            var cancha = new Cancha
            {
                Nombre = dto.Nombre,
                Tipo = dto.Tipo,
                Disponible = dto.Disponible,
                CampusId = dto.CampusId
            };

            _context.Cancha.Add(cancha);
            await _context.SaveChangesAsync();

            dto.CanchaId = cancha.CanchaId;

            return CreatedAtAction(nameof(GetCancha), new { id = cancha.CanchaId }, dto);
        }

        // PUT: api/Canchas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancha(int id, CanchaDTO dto)
        {
            if (id != dto.CanchaId)
                return BadRequest();

            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
                return NotFound();

            cancha.Nombre = dto.Nombre;
            cancha.Tipo = dto.Tipo;
            cancha.Disponible = dto.Disponible;
            cancha.CampusId = dto.CampusId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cancha.Any(e => e.CanchaId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Canchas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
                return NotFound();

            _context.Cancha.Remove(cancha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CanchaExists(int id)
        {
            return _context.Cancha.Any(e => e.CanchaId == id);
        }
    }
}

