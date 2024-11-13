using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;


namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Examen)]
    public class ExamenController : BaseController
    {
        public readonly IExamenEventHandlers _examenEventHandlers;
        public readonly IExamenQueryService _examenQueryService;
        public ExamenController(IExamenEventHandlers examenEventHandlers, IExamenQueryService examenQueryService)
        {
            _examenEventHandlers = examenEventHandlers;
            _examenQueryService = examenQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string? valor, int page, int pages, string column)
        {
            return Ok(await _examenQueryService.Get(valor, page, pages, column));
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            return Ok(await _examenQueryService.Find(id));
        }

        [HttpGet("getExamenPorEquiMedico")]
        public async Task<IActionResult> GetExamenPorEquiMedico(string? valor, string id, int page, int pages, string column)
        {
            return Ok(await _examenQueryService.GetExamenPorEquiMedico(valor, id, page, pages, column));
        }

        [HttpGet("getExamenPorSistemaExterno")]
        public async Task<IActionResult> GetExamenPorSistemaExterno(string? valor, string id, int page, int pages, string column)
        {
            return Ok(await _examenQueryService.GetExamenPorSistemaExterno(valor, id, page, pages, column));
        }
        [HttpGet("getExamenByIdArea/{idArea}")]
        public async Task<IActionResult> GetExamenByIdArea(string? idArea, string? nombreExam)
        {
            return Ok(await _examenQueryService.GetExamenByIdArea(idArea, nombreExam));
        }


        [HttpPost]
        public async Task<IActionResult> Post(ExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _examenEventHandlers.Post(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ExamenCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _examenEventHandlers.Put(id, command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _examenEventHandlers.Delete(id, user));
        }

        [HttpDelete("DeleteRango/{id}")]
        public async Task<IActionResult> DeleteRango(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _examenEventHandlers.DeleteRango(id, user));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(string id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _examenEventHandlers.State(id, user));
        }
    }
}
