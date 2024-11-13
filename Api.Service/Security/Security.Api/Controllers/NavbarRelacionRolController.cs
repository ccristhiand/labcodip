using Microsoft.AspNetCore.Mvc;
using Security.Service.Queries;

namespace Security.Api.Controllers
{
    [ApiController]
    [Route(Routes.NavbarRelacionRol)]
    public class NavbarRelacionRolController : BaseController
    {
        private readonly INavbarRelacionRolQueryService _navbarRelacionRolQueryService;
        public NavbarRelacionRolController(INavbarRelacionRolQueryService NavbarRelacionRolQueryService)
        {
            _navbarRelacionRolQueryService = NavbarRelacionRolQueryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string idRol)
        {
            var response = await _navbarRelacionRolQueryService.Get(idRol);

            return Ok(response);
        }
    }
}
