using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IContieneNombreRepository _service;

        public ReporteController(IContieneNombreRepository service)
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