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
            
            return reservas.ToList();
        }

        public async Task<string> RealizarReserva(Reserva reserva)
        {
            return await _reservaRepository.CrearReserva(reserva);
        }

        public async Task CancelarReserva(int reservaId, int usuarioId)
        {
            await _reservaRepository.BajarReserva(reservaId, usuarioId);
        }
    }


    
}
