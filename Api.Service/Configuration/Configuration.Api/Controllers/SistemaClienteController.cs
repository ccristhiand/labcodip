using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.SistemaCliente)]
    public class SistemaClienteController : BaseController
    {
        public readonly ISistemaClienteEventHandlers _sistemaClienteEventHandlers;
        public readonly ISistemaClienteQueryService _sistemaClienteQueryService;
        public SistemaClienteController(ISistemaClienteEventHandlers sistemaClienteEventHandlers, ISistemaClienteQueryService sistemaClienteQueryService)
        {
            _sistemaClienteEventHandlers = sistemaClienteEventHandlers;
            _sistemaClienteQueryService = sistemaClienteQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _sistemaClienteQueryService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _sistemaClienteQueryService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(SistemaClienteCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _sistemaClienteEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SistemaClienteCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _sistemaClienteEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _sistemaClienteEventHandlers.Delete(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _sistemaClienteEventHandlers.State(id, user));
        }
    }
}
