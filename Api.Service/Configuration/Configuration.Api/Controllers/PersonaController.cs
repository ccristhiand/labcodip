using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Persona)]
    public class PersonaController : BaseController
    {
        public readonly IPersonaEventHandlers _personaEventHandlers;
        public readonly IPersonaQueryService _personaQueryService;

        public PersonaController(IPersonaEventHandlers personaEventHandlers, IPersonaQueryService personaQueryService)
        {
            _personaEventHandlers = personaEventHandlers;
            _personaQueryService = personaQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _personaQueryService.Get());
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            return Ok(await _personaQueryService.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(PersonaCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _personaEventHandlers.Post(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, PersonaCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _personaEventHandlers.Put(id, command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _personaEventHandlers.Delete(id, user));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _personaEventHandlers.State(id, user));
        }
    }
}
