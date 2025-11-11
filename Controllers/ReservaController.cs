using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reservas_api.Contracts;

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
        [Route("GetReservasPorUsuario")]
        public async Task<IActionResult> GetReversasPorUsuario(int id)
        {
            var reservas = await _service.GetReservasDetallePorUsuario(id);
            return Ok(reservas);
        }
    }
}
