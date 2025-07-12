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
    public class CarrerasController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CarrerasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Carreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
        {
            return await _context.Carrera.ToListAsync();
        }

        // GET: api/Carreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(int id)
        {
            var item = await _context.Carrera.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST: api/Carreras
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(CarreraDTO dto)
        {
            var item = new Carrera
            {
                Nombre = dto.Nombre,
                FacultadId = dto.FacultadId
            };

            _context.Carrera.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCarrera), new { id = item.Id }, item);
        }

        // PUT: api/Carreras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, CarreraDTO dto)
        {
            var carrera = await _context.Carrera.FindAsync(id);

            if (carrera == null)
                return NotFound();

            carrera.Nombre = dto.Nombre;
            carrera.FacultadId = dto.FacultadId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Carrera.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Carreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            var item = await _context.Carrera.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.Carrera.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarreraExists(int id)
        {
            return _context.Carrera.Any(e => e.Id == id);
        }
    }
}

