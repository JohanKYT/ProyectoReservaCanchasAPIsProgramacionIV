using System.ComponentModel.DataAnnotations;

namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class FacultadDTO
    {
        public int FacultadId { get; set; }
        [Required(ErrorMessage = "El nombre del campus es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campus es obligatoria.")]
        public int CampusId { get; set; }
        public CampusDTO? Campus { get; set; }
    }

}
