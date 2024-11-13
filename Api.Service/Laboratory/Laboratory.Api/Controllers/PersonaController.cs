using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Persona)]
    public class PersonaController : BaseController
    {
        private readonly IPersonaQueryService _personaQueryService;

        public PersonaController(IPersonaQueryService personaQueryService)
        {
            _personaQueryService = personaQueryService;
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            var response = await _personaQueryService.Find(id);

            return Ok(response);
        }

    }
}