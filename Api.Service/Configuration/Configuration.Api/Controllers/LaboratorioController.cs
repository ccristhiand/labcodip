using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Laboratorio)]
    public class LaboratorioController : BaseController
    {
        public readonly ILaboratorioEventHandlers _laboratorioEventHandlers;
        public readonly ILaboratorioQueryService _laboratorioQueryService;
        public LaboratorioController(ILaboratorioEventHandlers laboratorioEventHandlers, ILaboratorioQueryService laboratorioQueryService)
        {
            _laboratorioEventHandlers = laboratorioEventHandlers;
            _laboratorioQueryService = laboratorioQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _laboratorioQueryService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _laboratorioQueryService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(LaboratorioCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _laboratorioEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, LaboratorioCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _laboratorioEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _laboratorioEventHandlers.Delete(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _laboratorioEventHandlers.State(id, user));
        }
    }
}
