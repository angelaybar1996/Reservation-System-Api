namespace reservas_api.Dtos
{
    public class ReservaDetalleDto
    {
        public int ReservaId { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime FechaReserva { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
