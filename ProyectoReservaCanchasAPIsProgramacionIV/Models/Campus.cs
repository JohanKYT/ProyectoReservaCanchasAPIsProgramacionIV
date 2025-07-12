using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public class Campus
    {
        [Key]
        public int CampusId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
    }
}
