using reservas_api.Dtos;
using reservas_api.Entities;


namespace reservas_api.Contracts
{
    public interface IReservaRepository
    {
        Task<List<ReservaDetalleDto>> GetReservas(int id);
        Task<string> CrearReserva(Reserva reserva);
        Task BajarReserva(int idReserva, int idUsuario);

    }
}
