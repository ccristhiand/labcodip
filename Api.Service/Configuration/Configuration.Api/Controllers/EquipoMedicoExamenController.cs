using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.EquipoMedicoExamen)]
    public class EquipoMedicoExamenController : BaseController
    {
        public readonly IEquipoMedicoExamenEventHandlers _equipoMedicoExamenEventHandlers;
        public readonly IEquipoMedicoExamenQueryService _equipoMedicoExamenQueryService;
        public EquipoMedicoExamenController(IEquipoMedicoExamenEventHandlers equipoMedicoExamenEventHandlers, IEquipoMedicoExamenQueryService equipoMedicoExamenQueryService)
        {
            _equipoMedicoExamenEventHandlers = equipoMedicoExamenEventHandlers;
            _equipoMedicoExamenQueryService = equipoMedicoExamenQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, string? id, int page, int pages, string column)
        {
            return Ok(await _equipoMedicoExamenQueryService.Get(valor, id, page, pages, column));
        }

        [HttpPost]
        public async Task<IActionResult> Post(EquipoMedicoExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _equipoMedicoExamenEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, EquipoMedicoExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _equipoMedicoExamenEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _equipoMedicoExamenEventHandlers.Delete(id, user));
        }
    }
}
