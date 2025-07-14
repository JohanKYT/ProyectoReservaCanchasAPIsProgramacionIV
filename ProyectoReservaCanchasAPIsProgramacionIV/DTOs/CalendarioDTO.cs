namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class CalendarioDTO
    {
        public int CalendarioId { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Estado { get; set; }
        public string? NotasDetallada { get; set; }

        public int CanchaId { get; set; }
        public string? NombreCancha { get; set; }

        public int PersonaUdlaId { get; set; }
        public string? NombrePersona { get; set; }
        public string? TipoPersona { get; set; }
    }
}
