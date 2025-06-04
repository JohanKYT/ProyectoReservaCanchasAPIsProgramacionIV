namespace ProyectoReservaCanchasAPIsProgramacionIV.DTOs
{
    public class FacultadDTO
    {
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public int CampusId { get; set; }
        public CampusDTO? Campus { get; set; }
    }

}
