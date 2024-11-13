using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;


namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.QCRango)]
    public class QCRangoController : BaseController
    {
        public readonly IQCRangoQueryService _qCRangoQueryService;
        public readonly IQCRangoEventHandlers _qCRangoEventHandlers;
        public QCRangoController(IQCRangoQueryService qCRangoQueryService, IQCRangoEventHandlers qCRangoEventHandlers)
        {
            _qCRangoQueryService = qCRangoQueryService;
            _qCRangoEventHandlers = qCRangoEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? id, string? idlote, string? idnivel)
        {
            return Ok(await _qCRangoQueryService.Get(id, idlote, idnivel));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id, string? idlote, string? idnivel)
        {
            return Ok(await _qCRangoQueryService.Find(id, idlote, idnivel));
        }

        [HttpPost]
        public async Task<IActionResult> Post(QCRangoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _qCRangoEventHandlers.Post(command));
        }

    }
}
