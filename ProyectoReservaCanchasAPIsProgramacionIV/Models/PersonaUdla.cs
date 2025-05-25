using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.Models
{
    public abstract class PersonaUdla
    {
        [Key]
        public int BannerId { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(10)]
        public string Telefono { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoPersona { get; set; }
    }
}
