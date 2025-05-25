using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Calendario
    {
        [Key]
        public int CalendarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;
        [MaxLength(500)]
        public string NotasDetallada { get; set; } = string.Empty;
        public int CanchaId { get; set; }
        [ForeignKey("CanchaId")]
        public Cancha? Cancha { get; set; }
    }

}
