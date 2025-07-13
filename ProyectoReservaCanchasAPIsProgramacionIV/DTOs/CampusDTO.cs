using System.ComponentModel.DataAnnotations;

public class CampusDTO
{
    public int CampusId { get; set; }

    [Required(ErrorMessage = "El nombre del campus es obligatorio.")]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "La dirección del campus es obligatoria.")]
    [StringLength(200)]
    public string Direccion { get; set; }
}

