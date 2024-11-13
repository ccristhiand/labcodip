using Configuration.Service.EventHandlers;
using Configuration.Service.EventHandlers.Commands;
using Configuration.Service.Queries;
using Microsoft.AspNetCore.Mvc;
using Security;

namespace Configuration.Api.Controllers
{
    [ApiController]
    [Route(Routes.TablaMaestra)]
    public class TablaMaestraController : BaseController
    {
        public readonly ITablaMaestraEventHandlers _tablaMaestraEventHandlers;
        public readonly ITablaMaestraQueryService _tablaMaestraQuery;
        public TablaMaestraController(ITablaMaestraEventHandlers tablaMaestraExamenEventHandlers, ITablaMaestraQueryService tablaMaestraQuery)
        {
            _tablaMaestraEventHandlers = tablaMaestraExamenEventHandlers;
            _tablaMaestraQuery = tablaMaestraQuery;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _tablaMaestraQuery.Get());
        }
        [HttpGet("find")]
        public async Task<IActionResult> Find(string id)
        {
            return Ok(await _tablaMaestraQuery.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(TablaMaestraCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _tablaMaestraEventHandlers.Post(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TablaMaestraCommand command)
        {
            command.user = CurrentUser.usuario;

            return Ok(await _tablaMaestraEventHandlers.Put(id, command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = CurrentUser.usuario;

            return Ok(await _tablaMaestraEventHandlers.Delete(id, user));
        }

    }
}
