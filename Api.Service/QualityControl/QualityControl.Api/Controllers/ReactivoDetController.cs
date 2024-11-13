using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;


namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.ReactivoDet)]
    public class ReactivoDetController : BaseController
    {
        public readonly IReactivoDetQueryService _reactivoDetQueryService;
        public readonly IReactivoDetEventHandlers _reactivoDetEventHandlers;
        public ReactivoDetController(IReactivoDetEventHandlers reactivoDetEventHandlers, IReactivoDetQueryService reactivoDetQueryService)
        {
            _reactivoDetQueryService = reactivoDetQueryService;
            _reactivoDetEventHandlers = reactivoDetEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id, int page, int pages)
        {
            return Ok(await _reactivoDetQueryService.Get(id, page, pages));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id, string? idarea)
        {
            return Ok(await _reactivoDetQueryService.Find(id, idarea));
        }

        [HttpGet("findExamen")]
        public async Task<IActionResult> FindExamen(string? id)
        {
            return Ok(await _reactivoDetQueryService.FindExamen(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReactivoDetCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _reactivoDetEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ReactivoDetCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _reactivoDetEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _reactivoDetEventHandlers.Delete(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _reactivoDetEventHandlers.State(id, user));
        }
    }
}
