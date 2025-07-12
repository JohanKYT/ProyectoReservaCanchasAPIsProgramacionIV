namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class CanchaDTO
    {
        public int CanchaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public bool Disponible { get; set; }

        public int CampusId { get; set; }
        public CampusDTO? Campus { get; set; } // Opcional para incluir detalles anidados de Campus
    }
}
