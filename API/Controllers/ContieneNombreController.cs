using API.Model;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContieneNombreController : ControllerBase
    {
        private readonly IContieneNombreRepository _contieneNombreService;

        public ContieneNombreController(IContieneNombreRepository service)
        {
            _contieneNombreService = service;
        }

        [HttpPost]
        public async Task<IActionResult> ContieneNombre([FromBody] ContieneNombreRequest request)
        {
            bool resultado = _contieneNombreService.ContieneNombre(request.Info, request.Nombre);

            await _contieneNombreService.CargarValidacionAsync(request.Info, request.Nombre, resultado);

            return Ok(new ContieneNombreResponse { Resultado = resultado });
        }
    }
}