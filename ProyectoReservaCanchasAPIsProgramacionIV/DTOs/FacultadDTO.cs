using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class FacultadDTO
    {
        public int FacultadId { get; set; }

        [Required(ErrorMessage = "El nombre de la facultad es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El ID del campus es obligatorio.")]
        public int CampusId { get; set; }

    }
}

