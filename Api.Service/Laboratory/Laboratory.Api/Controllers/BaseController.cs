using Microsoft.AspNetCore.Mvc;
using Persistence.Database.CurrentUser.Claims;
using Security;
using System.Security.Claims;

namespace Laboratory.Api.Controllers
{
    [ApiController]
    [Route(Routes.Base)]
    public class BaseController : Controller
    {
        public FrontEndUser CurrentUser { get { return new FrontEndUser(this.User as ClaimsPrincipal); } }
    }
}