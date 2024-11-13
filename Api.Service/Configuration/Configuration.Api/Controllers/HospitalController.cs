using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.Hospital)]
    public class HospitalController : BaseController
    {
        public readonly IHospitalEventHandlers _hospitalEventHandlers;
        public readonly IHospitalQueryService _hospitalQueryService;
        public HospitalController(IHospitalEventHandlers hospitalEventHandlers, IHospitalQueryService hospitalQueryService)
        {
            _hospitalEventHandlers = hospitalEventHandlers;
            _hospitalQueryService = hospitalQueryService;
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find()
        {
            return Ok(await _hospitalQueryService.Find());
        }

        [HttpPost]
        public async Task<IActionResult> Post(HospitalCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _hospitalEventHandlers.Post(command));
        }
    }
}
