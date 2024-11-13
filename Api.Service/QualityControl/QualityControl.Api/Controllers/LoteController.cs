using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;


namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.Lote)]
    public class LoteController : BaseController
    {
        public readonly ILoteQueryService _loteQueryService;
        public readonly ILoteEventHandlers _loteEventHandlers;
        public LoteController(ILoteEventHandlers loteEventHandlers, ILoteQueryService loteQueryService)
        {
            _loteEventHandlers = loteEventHandlers;
            _loteQueryService = loteQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id, int page, int pages)
        {
            return Ok(await _loteQueryService.Get(id, page, pages));
        }


        [HttpPost]
        public async Task<IActionResult> Post(LoteCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _loteEventHandlers.Post(command));
        }

    }
}
