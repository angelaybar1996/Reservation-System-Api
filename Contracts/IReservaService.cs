using reservas_api.Dtos;

namespace reservas_api.Contracts
{
    public interface IReservaService
    {
        Task<List<ReservaDetalleDto>> GetReservasDetallePorUsuario(int usuarioId);
    }
}
