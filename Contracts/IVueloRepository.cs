using reservas_api.Entities;

namespace reservas_api.Contracts
{
    public interface IVueloRepository
    {
        Task<List<Vuelo>> GetVuelos();
        Task BajarVuelo(int id);
    }
}
