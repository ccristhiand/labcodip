using Common.Utility;
using Laboratory.Service;
using Laboratory.Service.EventHandlers;
using Laboratory.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Orden)]
    public class OrdenController : BaseController
    {
        private readonly IOrdenQueryService _ordenQueryService;
        private readonly IOrdenEventHandlers _ordenEventHandlers;

        public OrdenController(IOrdenQueryService ordenQueryService, IOrdenEventHandlers ordenEventHandlers)
        {
            _ordenQueryService = ordenQueryService;
            _ordenEventHandlers = ordenEventHandlers;
        }

        [HttpPost("listarOrden")]
        public async Task<IActionResult> ListarOrden(OrdenReqQuery ordenReqQuery)
        {
            ordenReqQuery.Usuario = CurrentUser.usuario;

            var response = await _ordenQueryService.ListarOrden(ordenReqQuery);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            var user = CurrentUser.usuario;

            var response = await _ordenQueryService.Find(id, user);

            return Ok(response);
        }

        [HttpGet("findExamen")]
        public async Task<IActionResult> FindExamen(string? id, string idarea)
        {
            var user = CurrentUser.usuario;

            var response = await _ordenQueryService.FindExamen(id, idarea, user);

            return Ok(response);
        }

        [HttpGet("option")]
        public async Task<IActionResult> Option()
        {
            var user = CurrentUser.usuario;

            var response = await _ordenQueryService.Option(user);

            return Ok(response);
        }

        [HttpGet("examen")]
        public async Task<IActionResult> Examen(string? id, string idArea,string? text)
        {
            var response = await _ordenQueryService.Examen(id, idArea,text);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdenCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, OrdenUpdateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPut("addExamen/{id}")]
        public async Task<IActionResult> AddExamen(string id, OrdenAddCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.AddExamen(id, command);

            return Ok(response);
        }

        [HttpPut("postResult/{id}")]
        public async Task<IActionResult> PostResult(string id, OrdenValidateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.PostResult(id, command);

            return Ok(response);
        }

        [HttpPut("validateTecnico")]
        public async Task<IActionResult> ValidateTecnico(OrdenValidateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.ValidateTecnico(command);

            return Ok(response);
        }

        [HttpPut("validateMedico")]
        public async Task<IActionResult> ValidateMedico(OrdenValidateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.ValidateMedico(command);

            return Ok(response);
        }

        [HttpPut("quitarValidacion/{id}")]
        public async Task<IActionResult> QuitarValidacion(string id, OrdenValidateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _ordenEventHandlers.QuitarValidacion(id, command.idArea!, command.user);

            return Ok(response);
        }

        [HttpPost("valTipoMuestra")]
        public async Task<IActionResult> ValTipoMuestra(RequestReport request)
        {
            var result = await _ordenQueryService.ValTipoMuestra(request);

            return Ok(result);
        }

    }
}