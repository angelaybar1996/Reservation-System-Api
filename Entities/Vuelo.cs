namespace reservas_api.Entities
{
    public class Vuelo
    {
        public int VueloId { get; set; }
        public int AerolineaId { get; set; }
        public string? Origen { get; set; }
        public string? Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }

    }
}
