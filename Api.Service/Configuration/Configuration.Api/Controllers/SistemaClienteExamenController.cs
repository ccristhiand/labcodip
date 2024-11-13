using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.SistemaClienteExamen)]
    public class SistemaClienteExamenController : BaseController
    {
        public readonly ISistemaClienteExamenEventHandlers _sistemaClienteExamenEventHandlers;
        public readonly ISistemaClienteExamenQueryService _sistemaClienteExamenQueryService;
        public SistemaClienteExamenController(ISistemaClienteExamenEventHandlers sistemaExamenClienteEventHandlers, ISistemaClienteExamenQueryService sistemaClienteExamenQueryService)
        {
            _sistemaClienteExamenEventHandlers = sistemaExamenClienteEventHandlers;
            _sistemaClienteExamenQueryService = sistemaClienteExamenQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, string? id, int page, int pages, string column)
        {
            return Ok(await _sistemaClienteExamenQueryService.Get(valor, id, page, pages, column));
        }

        [HttpPost]
        public async Task<IActionResult> Post(SistemaClienteExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _sistemaClienteExamenEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SistemaClienteExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _sistemaClienteExamenEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _sistemaClienteExamenEventHandlers.Delete(id, user));
        }
    }
}
