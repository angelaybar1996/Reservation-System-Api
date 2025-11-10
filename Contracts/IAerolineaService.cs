using reservas_api.Entities;

namespace reservas_api.Contracts
{
    public interface IAerolineaService
    {
        Task<List<Aerolinea>> ObtenerAerolineas();
    }
}
