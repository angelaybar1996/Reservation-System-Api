using reservas_api.Contracts;
using reservas_api.Dtos;
using reservas_api.Entities;



namespace reservas_api.Services
{
    public class ReservaService : IReservaService
    {

        private readonly IReservaRepository _reservaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IVueloRepository _vueloRepository;
        public ReservaService(
            IReservaRepository reservaRepository,
            IUsuarioRepository usuarioRepository,
            IVueloRepository vueloRepository)
        {
            _reservaRepository = reservaRepository;
            _usuarioRepository = usuarioRepository;
            _vueloRepository = vueloRepository;
        }

        public async Task<List<ReservaDetalleDto>> GetReservasDetallePorUsuario(int usuarioId)
        {
            var reservas = await _reservaRepository.GetReservas(usuarioId);
            var usuario = await _usuarioRepository.GetUsuario(usuarioId);
            var vuelos = await _vueloRepository.GetVuelos(usuarioId);

            var resultado = reservas.Select(r =>
            {
                var vuelo = vuelos.FirstOrDefault(v => v.VueloId == r.VueloId);

                return new ReservaDetalleDto
                {
                    ReservaId = r.ReservaId,
                    Cliente = $"{usuario?.Nombre} {usuario?.Apellido}",
                    Destino = vuelo?.Destino ?? "N/A",
                    FechaReserva = r.FechaReserva,
                    Estado = r.Estado ?? "Desconocido"
                };
            }).ToList();

            return resultado;
        }
    }


    
}
