using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Cancha
    {
        [Key]
        public int CanchaId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; } 

        [MaxLength(50)]
        public string Tipo { get; set; } 

        public bool Disponible { get; set; } = true; 

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();
    }
}
