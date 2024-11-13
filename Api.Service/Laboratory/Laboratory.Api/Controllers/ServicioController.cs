using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Servicio)]
    public class ServicioController : BaseController
    {
        private readonly IServicioQueryService _servicioQueryService;
        private readonly IServicioEventHandlers _servicioEventHandlers;

        public ServicioController(IServicioQueryService servicioQueryService, IServicioEventHandlers servicioEventHandlers)
        {
            _servicioQueryService = servicioQueryService;
            _servicioEventHandlers = servicioEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages)
        {
            var response = await _servicioQueryService.Get(valor, page, pages);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            var response = await _servicioQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServicioCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _servicioEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ServicioCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _servicioEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _servicioEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _servicioEventHandlers.Delete(id, user);

            return Ok(response);
        }

    }
}