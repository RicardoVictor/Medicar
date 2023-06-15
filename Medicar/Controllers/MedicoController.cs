using Medicar.Domain.Commands.Requests;
using Medicar.Domain.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Medicar.Controllers
{
    [ApiController]
    [Route("medicos")]
    public class MedicoController : ControllerBase
    {

        private readonly ILogger<MedicoController> _logger;
        private readonly IMedicoService _medicoService;

        public MedicoController(ILogger<MedicoController> logger, IMedicoService medicoService)
        {
            _logger = logger;
            _medicoService = medicoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _medicoService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _medicoService.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(MedicoRequest medico)
        {
            try
            {
                await _medicoService.PostAsync(medico);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " CRM: " + medico.CRM + ".");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _medicoService.DeleteAsync(id);
            return Ok();
        }
    }
}