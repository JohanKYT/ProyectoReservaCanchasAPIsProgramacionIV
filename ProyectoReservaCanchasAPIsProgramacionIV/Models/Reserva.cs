using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public ICollection<ReservaImplemento> ReservaImplementos { get; set; } = new List<ReservaImplemento>();
        public ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
        public int CanchaId { get; set; }
        [ForeignKey("CanchaId")]    
        public Cancha Cancha { get; set; }
        public int PersonaUdlaId { get; set; }
        [ForeignKey("PersonaUdlaId")]
        public PersonaUdla PersonaUdla { get; set; }
    }
}
