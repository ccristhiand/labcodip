using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;


namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.Reactivo)]
    public class ReactivoController : BaseController
    {
        public readonly IReactivoQueryService _reactivoQueryService;
        public readonly IReactivoEventHandlers _reactivoEventHandlers;
        public ReactivoController(IReactivoEventHandlers reactivoEventHandlers, IReactivoQueryService reactivoQueryService)
        {
            _reactivoQueryService = reactivoQueryService;
            _reactivoEventHandlers = reactivoEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? idarea, int page, int pages)
        {
            return Ok(await _reactivoQueryService.Get(idarea, page, pages));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _reactivoQueryService.Find(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReactivoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _reactivoEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ReactivoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _reactivoEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _reactivoEventHandlers.Delete(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _reactivoEventHandlers.State(id, user));
        }
    }
}
