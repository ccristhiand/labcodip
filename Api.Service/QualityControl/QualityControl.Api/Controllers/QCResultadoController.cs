using Laboratory.Service.EventHandlers;
using Microsoft.AspNetCore.Mvc;
using QualityControl.Service.EventHandlers;
using QualityControl.Service.Queries;
using Security;

namespace QualityControl.Api.Controllers
{
    [ApiController]
    [Route(Routes.QCResultado)]
    public class QCResultadoController : BaseController
    {
        public readonly IQCResultadoQueryService _qCResultadoQueryService;
        public readonly IQCResultadoEventHandlers _qCResultadoEventHandlers;

        public QCResultadoController(IQCResultadoQueryService qCResultadoQueryService, IQCResultadoEventHandlers qCResultadoEventHandlers)
        {
            _qCResultadoQueryService = qCResultadoQueryService;
            _qCResultadoEventHandlers = qCResultadoEventHandlers;
        }


        [HttpGet("getArea")]
        public async Task<IActionResult> GetArea()
        {
            return Ok(await _qCResultadoQueryService.GetArea());
        }

        [HttpGet("getControl")]
        public async Task<IActionResult> GetControl(string id)
        {
            return Ok(await _qCResultadoQueryService.GetControl(id));
        }

        [HttpGet("getExamen")]
        public async Task<IActionResult> GetExamen(string id)
        {
            return Ok(await _qCResultadoQueryService.GetExamen(id));
        }

        [HttpGet("getResultado")]
        public async Task<IActionResult> GetResultado(string? idreactivodet, string? idexamen, string? idlote, string? idnivel, DateTime? dateini, DateTime? datefin)
        {
            return Ok(await _qCResultadoQueryService.GetResultado(idreactivodet, idexamen, idlote, idnivel, dateini, datefin));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ResultadoCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _qCResultadoEventHandlers.Post(command));
        }

    }
}
