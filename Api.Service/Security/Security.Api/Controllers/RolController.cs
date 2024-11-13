using Microsoft.AspNetCore.Mvc;
using Security.Service.EventHandlers;
using Security.Service.Queries;

namespace Security.Api.Controllers
{

    [ApiController]
    [Route(Routes.Rol)]
    public class RolController : BaseController
    {
        private readonly IRolQueryService _rolQueryService;
        private readonly IRolEventHandlers _rolEventHandlers;

        public RolController(IRolQueryService rolQueryService, IRolEventHandlers rolEventHandlers)
        {
            _rolQueryService = rolQueryService;
            _rolEventHandlers = rolEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _rolQueryService.Get();

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _rolQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RolCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _rolEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, RolCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _rolEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _rolEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _rolEventHandlers.Delete(id, user);

            return Ok(response);
        }
    }
}