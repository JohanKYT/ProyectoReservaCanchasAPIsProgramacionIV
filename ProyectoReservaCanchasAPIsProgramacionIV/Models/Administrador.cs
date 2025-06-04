using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Administrador : PersonaUdla
    {
        public Administrador()
        {
            TipoPersona = "Administrador";
        }
        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public Facultad? Facultad { get; set; }
    }
}