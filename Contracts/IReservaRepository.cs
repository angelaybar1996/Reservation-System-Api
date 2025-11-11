using reservas_api.Entities;


namespace reservas_api.Contracts
{
    public interface IReservaRepository
    {
        Task<List<Reserva>> GetReservas(int id);
        Task<string> CrearReserva(Reserva reserva);
        Task CancelarReserva(int idReserva, int idUsuario);

    }
}
