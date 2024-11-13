using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;


namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.Nivel)]
    public class NivelController : BaseController
    {
        public readonly INivelQueryService _nivelQueryService;
        public readonly INivelEventHandlers _nivelEventHandlers;
        public NivelController(INivelEventHandlers nivelEventHandlers, INivelQueryService nivelQueryService)
        {
            _nivelEventHandlers = nivelEventHandlers;
            _nivelQueryService = nivelQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int pages)
        {
            return Ok(await _nivelQueryService.Get(page, pages));
        }


        [HttpPost]
        public async Task<IActionResult> Post(NivelCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _nivelEventHandlers.Post(command));
        }

    }
}
