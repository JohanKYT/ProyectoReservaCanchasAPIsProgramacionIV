using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Calendario
    {
        [Key]
        public int CalendarioId { get; set; }

        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }

        public string Estado { get; set; } = "Pendiente";
        public string NotasDetallada { get; set; } = string.Empty;

        public int CanchaId { get; set; }
        [ForeignKey("CanchaId")]
        public Cancha Cancha { get; set; }

        public int PersonaUdlaId { get; set; }
        [ForeignKey("PersonaUdlaId")]
        public PersonaUdla PersonaUdla { get; set; }
    }

}
