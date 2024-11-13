using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Origen)]
    public class OrigenController : BaseController
    {
        private readonly IOrigenQueryService _origenQueryService;
        private readonly IOrigenEventHandlers _origenEventHandlers;

        public OrigenController(IOrigenQueryService origenQueryService, IOrigenEventHandlers origenEventHandlers)
        {
            _origenQueryService = origenQueryService;
            _origenEventHandlers = origenEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages)
        {
            var response = await _origenQueryService.Get(valor, page, pages);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _origenQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrigenCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _origenEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, OrigenCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _origenEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _origenEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _origenEventHandlers.Delete(id, user);

            return Ok(response);
        }

    }
}