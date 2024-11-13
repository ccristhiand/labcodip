using Microsoft.AspNetCore.Mvc;
using Security.Service.EventHandlers;
using Security.Service.Queries;

namespace Security.Api.Controllers
{
    [ApiController]
    [Route(Routes.Navbar)]
    public class NavbarController : BaseController
    {
        private readonly INavbarQueryService _navbarQueryService;
        private readonly INavbarEventHandlers _navbarEventHandlers;

        public NavbarController(INavbarQueryService navbarQueryService, INavbarEventHandlers navbarEventHandlers)
        {
            _navbarQueryService = navbarQueryService;
            _navbarEventHandlers = navbarEventHandlers;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _navbarQueryService.Get();

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(int id)
        {
            var response = await _navbarQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NavbarCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _navbarEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, NavbarCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _navbarEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(int id)
        {
            var user = CurrentUser.usuario;

            var response = await _navbarEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = CurrentUser.usuario;

            var response = await _navbarEventHandlers.Delete(id, user);

            return Ok(response);
        }
    }
}