using reservas_api.Dtos;
using reservas_api.Entities;

namespace reservas_api.Contracts
{
    public interface IReservaService
    {
        Task<List<ReservaDetalleDto>> GetReservasDetallePorUsuario(int usuarioId);

        Task<string> RealizarReserva(Reserva reserva);

        Task CancelarReserva(int idReserva, int idUsuario);
    }
}
