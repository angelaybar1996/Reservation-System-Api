using reservas_api.Contracts;
using reservas_api.Entities;


namespace reservas_api.Services
{
    public class AerolineaService:IAerolineaService
    {
        private readonly IAerolineaRepository _aerolineaRepository;
        public AerolineaService(IAerolineaRepository aerolineaRepository)
        {
            _aerolineaRepository = aerolineaRepository;
        }

        public async Task<List<Aerolinea>> ObtenerAerolineas()
        {
          return await _aerolineaRepository.GetAerolineas();
        }
    }
}
