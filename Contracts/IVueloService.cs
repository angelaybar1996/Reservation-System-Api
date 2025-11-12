using reservas_api.Entities;

namespace reservas_api.Contracts
{
    public interface IVueloService
    {
        Task<List<Vuelo>> ObtenerVuelos();
        Task CancelarVuelo(int id);
    }
}
