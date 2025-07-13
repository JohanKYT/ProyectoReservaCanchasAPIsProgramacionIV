namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class AdministradorDTO
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int FacultadId { get; set; }
    }

}
