using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Carrera
    {
        [Key]
        public int CarreraId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        public int FacultadId { get; set; }
        [ForeignKey("FacultadId")]
        public Facultad? Facultad { get; set; }
    }
}
