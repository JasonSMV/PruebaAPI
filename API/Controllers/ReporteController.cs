using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IContieneNombreService _service;

        public ReporteController(IContieneNombreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetReporte()
        {
            var reporte = await _service.EstadisticasAsync();
            return Ok(reporte);
        }
    }
}