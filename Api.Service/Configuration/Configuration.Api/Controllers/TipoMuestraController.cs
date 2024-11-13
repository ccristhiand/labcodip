using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.TipoMuestra)]
    public class TipoMuestraController : BaseController
    {

        public readonly ITipoMuestraEventHandlers _tipoMuestraEventHandlers;
        public readonly ITipoMuestraQueryService _tipoMuestraQueryService;
        public TipoMuestraController(ITipoMuestraEventHandlers tipoMuestraEventHandlers, ITipoMuestraQueryService tipoMuestraQueryService)
        {
            _tipoMuestraEventHandlers = tipoMuestraEventHandlers;
            _tipoMuestraQueryService = tipoMuestraQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _tipoMuestraQueryService.Get(valor, page, pages, column));
        }
        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _tipoMuestraQueryService.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(TipoMuestraCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _tipoMuestraEventHandlers.Post(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, TipoMuestraCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _tipoMuestraEventHandlers.Put(id, command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _tipoMuestraEventHandlers.Delete(id, user));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _tipoMuestraEventHandlers.State(id, user));
        }
    }
}
