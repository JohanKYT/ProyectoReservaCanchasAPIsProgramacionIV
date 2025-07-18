﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoReservaCanchasAPIsProgramacionIV.Data;
using ProyectoReservaCanchasAPIsProgramacionIV.Models;
using ProyectoReservaCanchasAPIsProgramacionIV.DTOs;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendariosController : ControllerBase
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CalendariosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: api/Calendarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarioDTO>>> GetCalendarios()
        {
            var calendarios = await _context.Calendario
                .Include(c => c.Cancha)
                .Include(c => c.PersonaUdla)
                .Select(c => new CalendarioDTO
                {
                    CalendarioId = c.CalendarioId,
                    FechaHoraInicio = c.FechaHoraInicio,
                    FechaHoraFin = c.FechaHoraFin,
                    Estado = c.Estado,
                    NotasDetallada = c.NotasDetallada,
                    CanchaId = c.CanchaId,
                    NombreCancha = c.Cancha != null ? c.Cancha.Nombre : null,
                    PersonaUdlaId = c.PersonaUdlaId,
                    NombrePersona = c.PersonaUdla != null ? c.PersonaUdla.Nombre : null,
                    TipoPersona = EF.Property<string>(c.PersonaUdla, "TipoPersona")
                })
                .ToListAsync();

            return calendarios;
        }

        // GET: api/Calendarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarioDTO>> GetCalendario(int id)
        {
            var calendario = await _context.Calendario
                .Include(c => c.Cancha)
                .Include(c => c.PersonaUdla)
                .Where(c => c.CalendarioId == id)
                .Select(c => new CalendarioDTO
                {
                    CalendarioId = c.CalendarioId,
                    FechaHoraInicio = c.FechaHoraInicio,
                    FechaHoraFin = c.FechaHoraFin,
                    Estado = c.Estado,
                    NotasDetallada = c.NotasDetallada,
                    CanchaId = c.CanchaId,
                    NombreCancha = c.Cancha != null ? c.Cancha.Nombre : null,
                    PersonaUdlaId = c.PersonaUdlaId,
                    NombrePersona = c.PersonaUdla != null ? c.PersonaUdla.Nombre : null,
                    TipoPersona = EF.Property<string>(c.PersonaUdla, "TipoPersona")
                })
                .FirstOrDefaultAsync();

            if (calendario == null)
                return NotFound();

            return calendario;
        }

        // POST: api/Calendarios
        [HttpPost]
        public async Task<ActionResult<Calendario>> PostCalendario(CalendarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var calendario = new Calendario
            {
                FechaHoraInicio = dto.FechaHoraInicio,
                FechaHoraFin = dto.FechaHoraFin,
                Estado = dto.Estado,
                NotasDetallada = dto.NotasDetallada,
                CanchaId = dto.CanchaId,
                PersonaUdlaId = dto.PersonaUdlaId
            };

            _context.Calendario.Add(calendario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalendario), new { id = calendario.CalendarioId }, calendario);
        }

        // PUT: api/Calendarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendario(int id, CalendarioDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var calendario = await _context.Calendario.FindAsync(id);
            if (calendario == null)
                return NotFound();

            calendario.FechaHoraInicio = dto.FechaHoraInicio;
            calendario.FechaHoraFin = dto.FechaHoraFin;
            calendario.Estado = dto.Estado;
            calendario.NotasDetallada = dto.NotasDetallada;
            calendario.CanchaId = dto.CanchaId;
            calendario.PersonaUdlaId = dto.PersonaUdlaId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Calendarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendario(int id)
        {
            var calendario = await _context.Calendario.FindAsync(id);
            if (calendario == null)
                return NotFound();

            _context.Calendario.Remove(calendario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarioExists(int id)
        {
            return _context.Calendario.Any(e => e.CalendarioId == id);
        }
    }
}