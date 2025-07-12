namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class CarreraDTO
    {
        public int CarreraId { get; set; }
        public string Nombre { get; set; }

        public int FacultadId { get; set; }
        public FacultadDTO? Facultad { get; set; }
    }
}
