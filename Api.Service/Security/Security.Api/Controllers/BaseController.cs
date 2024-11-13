using Microsoft.AspNetCore.Mvc;
using Persistence.Database.CurrentUser.Claims;
using System.Security.Claims;

namespace Security.Api.Controllers
{
    [ApiController]
    [Route(Routes.Base)]
    public class BaseController : Controller
    {
        public FrontEndUser CurrentUser { get { return new FrontEndUser(this.User as ClaimsPrincipal); } }
    }
}