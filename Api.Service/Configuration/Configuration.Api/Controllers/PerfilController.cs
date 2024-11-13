using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries.Query;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Perfil)]
    public class PerfilController : BaseController
    {
        public readonly IPerfilEventHandlers _perfilEvenHandler;
        public readonly IPerfilQueryService _perfilQueryService;
        public PerfilController(IPerfilEventHandlers perfilEvenHandler, IPerfilQueryService perfilQueryService)
        {
            _perfilEvenHandler = perfilEvenHandler;
            _perfilQueryService = perfilQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PerfilCommand command)
        {
            command.User = CurrentUser.usuario;

            return Ok(await _perfilEvenHandler.Post(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, PerfilCommand command)
        {
            command.User = CurrentUser.usuario;

            return Ok(await _perfilEvenHandler.Put(command, id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _perfilEvenHandler.Delete(id, user));
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages)
        {
            return Ok(await _perfilQueryService.Get(valor, page, pages));
        }

        [HttpGet("GetPerfiles")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _perfilQueryService.Get());
        }


        [HttpGet("find/{id}")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _perfilQueryService.Find(id));
        }
    }
}
