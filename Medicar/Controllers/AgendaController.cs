using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Handlers.Interfaces;
using Medicar.Domain.Views;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Controllers
{
    [ApiController]
    [Route("agendas")]
    public class AgendaController : ControllerBase
    {

        private readonly ILogger<AgendaController> _logger;
        private readonly IAgendaService _agendaService;

        public AgendaController(ILogger<AgendaController> logger, IAgendaService agendaService)
        {
            _logger = logger;
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] AgendaFilter filter)
        {
            return Ok(await _agendaService.GetAsync(filter));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(AgendaRequest agenda)
        {
            try
            {
                await _agendaService.PostAsync(agenda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}