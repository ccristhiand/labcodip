using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Area)]
    public class AreaController : BaseController
    {
        public readonly IAreaEventHandlers _areaEventHandlers;
        public readonly IAreaQueryService _areaQueryService;


        public AreaController(IAreaEventHandlers areaEventHandlers, IAreaQueryService areaQueryService)
        {
            _areaEventHandlers = areaEventHandlers;
            _areaQueryService = areaQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _areaQueryService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _areaQueryService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(AreaCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _areaEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, AreaCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _areaEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            string user = CurrentUser.usuario;

            return Ok(await _areaEventHandlers.Delete(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            string user = CurrentUser.usuario;

            return Ok(await _areaEventHandlers.State(id, user));
        }
    }
}
