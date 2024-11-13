using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Medico)]
    public class MedicoController : BaseController
    {
        private readonly IMedicoQueryService _medicoQueryService;
        private readonly IMedicoEventHandlers _medicoEventHandlers;

        public MedicoController(IMedicoQueryService medicoQueryService, IMedicoEventHandlers medicoEventHandlers)
        {
            _medicoQueryService = medicoQueryService;
            _medicoEventHandlers = medicoEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages)
        {
            var response = await _medicoQueryService.Get(valor, page, pages);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            var response = await _medicoQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MedicoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _medicoEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, MedicoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _medicoEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _medicoEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _medicoEventHandlers.Delete(id, user);

            return Ok(response);
        }
    }
}