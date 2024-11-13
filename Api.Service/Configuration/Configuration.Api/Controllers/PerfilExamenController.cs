using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;
namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.PerfilExamen)]
    public class PerfilExamenController : BaseController
    {
        public readonly IPerfilExamenEventHandlers _perfiExamenlEvenHandler;
        public readonly IPerfilExamenQueryService _perfiExamenService;

        public PerfilExamenController(IPerfilExamenEventHandlers perfilExamenEvenHandler)
        {
            _perfiExamenlEvenHandler = perfilExamenEvenHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PerfilExamenCommand command)
        {
            command.User = CurrentUser.usuario;

            return Ok(await _perfiExamenlEvenHandler.Post(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(PerfilExamenCommand command, string id)
        {
            command.User = CurrentUser.usuario;

            return Ok(await _perfiExamenlEvenHandler.Put(command, id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;
            return Ok(await _perfiExamenlEvenHandler.Delete(id, user));
        }
        [HttpPost("PostMasivo")]
        public async Task<IActionResult> PostMasivo(List<PerfilExamenCommand>? command)
        {
            var user = CurrentUser.usuario;

            return Ok(await _perfiExamenlEvenHandler.PostMasivo(command, user));
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _perfiExamenService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _perfiExamenService.FindByIdPerfil(id));
        }

    }
}
