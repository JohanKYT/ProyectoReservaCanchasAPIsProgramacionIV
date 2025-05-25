using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Estudiante : PersonaUdla
    {
        public Estudiante()
        {
            TipoPersona = "Estudiante";
        }
        public int CarreraId { get; set; }
        [ForeignKey("CarreraId")]
        public Carrera? Carrera { get; set; }
    }
}