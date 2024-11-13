using Jwt.AuthenticationManagen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Service.EventHandlers;
using Security.Service.Queries;

namespace Security.Api.Controllers
{

    [ApiController]
    [Route(Routes.Usuario)]
    public class UsuarioController : BaseController
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IUsuarioQueryService _usuarioQueryService;
        private readonly IUsuarioEventHandlers _usuarioEventHandlers;

        public UsuarioController(JwtTokenHandler jwtTokenHandler
            , IUsuarioQueryService usuarioQueryService, IUsuarioEventHandlers usuarioEventHandlers
            )
        {
            _jwtTokenHandler = jwtTokenHandler;
            _usuarioQueryService = usuarioQueryService;
            _usuarioEventHandlers = usuarioEventHandlers;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCreateCommand request)
        {
            var authentication = _jwtTokenHandler.GenerateJwtToken(request.usuario!, request.password!, request.domain!);
            if (authentication == null) return Unauthorized();

            return Ok(authentication);
        }

        [HttpGet("loginRefresh")]
        public async Task<IActionResult> LoginRefresh(string token)
        {
            var authentication = _jwtTokenHandler.RefreshJwtToken(token);
            if (authentication == null) return Unauthorized();

            return Ok(authentication);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string idlab, string idarea, int page, int pages)
        {
            var response = await _usuarioQueryService.Get(idlab, idarea, page, pages);

            return Ok(response);
        }

        [HttpGet("find")]
        public async Task<IActionResult> Find(string? id)
        {
            var response = await _usuarioQueryService.Find(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuarioCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _usuarioEventHandlers.Post(command);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, UsuarioCreateCommand command)
        {
            command.user = CurrentUser.usuario;

            var response = await _usuarioEventHandlers.Put(id, command);

            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> State(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _usuarioEventHandlers.State(id, user);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = CurrentUser.usuario;

            var response = await _usuarioEventHandlers.Delete(id, user);

            return Ok(response);
        }
    }
}