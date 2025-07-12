namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class CalendarioDTO
    {
        public int CalendarioId { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public string NotasDetallada { get; set; } = string.Empty;

        public int CanchaId { get; set; }
        public int PersonaUdlaId { get; set; }
    }
}
