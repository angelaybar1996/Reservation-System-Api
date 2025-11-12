using reservas_api.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using reservas_api.Contracts;

namespace reservas_api.Services
{
    public class VueloService: IVueloService
    {
        private readonly IVueloRepository _VueloRepository;

        public VueloService(IVueloRepository vueloRepository)
        {
            _VueloRepository = vueloRepository;
        }

        public async Task<List<Vuelo>> ObtenerVuelos()
        {
            return await _VueloRepository.GetVuelos();
        }

        public async Task CancelarVuelo(int id)
        {
            await _VueloRepository.BajarVuelo(id);
        }
    }
}
