using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reservas_api.Services;
using reservas_api.Models;

namespace reservas_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineaController : ControllerBase
    {
        private readonly AerolineaService _service;
        public AerolineaController(AerolineaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAerolineas")]
        public async Task<IActionResult>GetAerolineas()
        {
            var aerolineas=await _service.GetAerolineas();
            return Ok(aerolineas);
        }
    }
}
