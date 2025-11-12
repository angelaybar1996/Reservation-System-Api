using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reservas_api.Contracts;
using reservas_api.Entities;

namespace reservas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public async Task<IActionResult> GetReversasPorUsuario(int id)
        {
            var reservas = await _service.GetReservasDetallePorUsuario(id);
            return Ok(reservas);
        }

        [HttpPost]
        [Route("Realizar")]
        public async Task<IActionResult> RealizarReserva(Reserva reserva)
        {
            var retorno = await _service.RealizarReserva(reserva);
            return Ok(retorno);
        }

        [HttpPost]
        [Route("Cancelar/{idReserva}/{idUsuario}")]
        public async Task<IActionResult> CancelarReserva(int idReserva, int idUsuario)
        {
            await _service.CancelarReserva(idReserva,idUsuario);
            return Ok();
        }
    }
}
