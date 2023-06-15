using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Controllers
{
    [ApiController]
    [Route("consultas")]
    public class ConsultaController : ControllerBase
    {

        private readonly ILogger<ConsultaController> _logger;
        private readonly IConsultaService _consultaService;

        public ConsultaController(ILogger<ConsultaController> logger, IConsultaService consultaService)
        {
            _logger = logger;
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _consultaService.GetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ConsultaRequest consulta)
        {
            try
            {
                await _consultaService.PostAsync(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _consultaService.DeleteAsync(id);
            return Ok();
        }
    }
}