using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reservas_api.Contracts;

namespace reservas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {
        private readonly IVueloService _service;

        public VueloController(IVueloService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ObtenerVuelos")]
        public async Task<IActionResult> ObtenerVuelos()
        {
            var vuelos = await _service.ObtenerVuelos();
            return Ok(vuelos);
        }

        [HttpPost]
        [Route("Cancelar/{id}")]
        public async Task<IActionResult> CancelarVuelo(int id)
        {
            await _service.CancelarVuelo(id);
            return Ok(new
            {
                success = true,
                message = "El vuelo fue cancelado correctamente."
            });
        }


    }
}
