using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Procedencia)]
    public class ProcedenciaController : BaseController
    {
        private readonly IProcedenciaQueryService _procedenciaQueryService;
        private readonly IProcedenciaEventHandlers _procedenciaEventHandlers;

        public ProcedenciaController(IProcedenciaQueryService procedenciaQueryService, IProcedenciaEventHandlers procedenciaEventHandlers)
        {
            _procedenciaQueryService = procedenciaQueryService;
            _procedenciaEventHandlers = procedenciaEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages)
        {
            var response = await _procedenciaQueryService.Get(valor, page, pages);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _procedenciaQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProcedenciaCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _procedenciaEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ProcedenciaCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _procedenciaEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _procedenciaEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _procedenciaEventHandlers.Delete(id, user);

            return Ok(response);
        }

    }
}