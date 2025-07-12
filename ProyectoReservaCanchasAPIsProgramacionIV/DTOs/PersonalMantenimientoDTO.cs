namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class PersonalMantenimientoDTO
    {
        public int BannerId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TipoPersona { get; set; }
    }
}
