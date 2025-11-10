using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reservas_api.Services;
using reservas_api.Entities;
using reservas_api.Contracts;

namespace reservas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineaController : ControllerBase
    {
        private readonly IAerolineaService _service;
        public AerolineaController(IAerolineaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAerolineas")]
        public async Task<IActionResult>GetAerolineas()
        {
            var aerolineas=await _service.ObtenerAerolineas();
            return Ok(aerolineas);
        }
    }
}
