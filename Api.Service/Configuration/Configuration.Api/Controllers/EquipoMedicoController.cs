using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.EquipoMedico)]
    public class EquipoMedicoController : BaseController
    {
        public readonly IEquipoMedicoEventHandlers _equipoMedicoEventHandlers;
        public readonly IEquipoMedicoQueryService _equipoMedicoQueryService;
        public EquipoMedicoController(IEquipoMedicoEventHandlers equipoMedicoEventHandlers, IEquipoMedicoQueryService equipoMedicoQuery)
        {
            _equipoMedicoEventHandlers = equipoMedicoEventHandlers;
            _equipoMedicoQueryService = equipoMedicoQuery;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _equipoMedicoQueryService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _equipoMedicoQueryService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(EquipoMedicoCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _equipoMedicoEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EquipoMedicoCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _equipoMedicoEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _equipoMedicoEventHandlers.Delete(id, user));
        }

        [HttpDelete("DeleteAnalizador/{id}")]
        public async Task<IActionResult> DeleteAnalizador(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _equipoMedicoEventHandlers.DeleteAnalizador(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _equipoMedicoEventHandlers.State(id, user));
        }
    }
}
