namespace reservas_api.Entities
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int UsuarioId { get; set; }
        public int VueloId { get; set; }
        public DateTime FechaReserva { get; set; }
        public string? Estado { get; set; }

    }
}
