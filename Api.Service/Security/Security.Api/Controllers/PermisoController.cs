using Microsoft.AspNetCore.Mvc;
using Security.Service.EventHandlers;
using Security.Service.Queries;

namespace Security.Api.Controllers
{
    [ApiController]
    [Route(Routes.Permiso)]
    public class PermisoController : BaseController
    {
        private readonly IPermisoQueryService _permisoQueryService;
        private readonly IPermisoEventHandlers _permisoEventHandlers;

        public PermisoController(IPermisoQueryService permisoQueryService, IPermisoEventHandlers permisoEventHandlers)
        {
            _permisoQueryService = permisoQueryService;
            _permisoEventHandlers = permisoEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _permisoQueryService.Get();

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _permisoQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PermisoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _permisoEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, PermisoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _permisoEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _permisoEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _permisoEventHandlers.Delete(id, user);

            return Ok(response);
        }
    }
}