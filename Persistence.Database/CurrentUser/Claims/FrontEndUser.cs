using System.Security.Claims;

namespace Persistence.Database.CurrentUser.Claims
{
    public class FrontEndUser : ClaimsPrincipal
    {
        public FrontEndUser(ClaimsPrincipal principal)
            : base(principal)
        { }
        public string usuario { get { return Identity.IsAuthenticated ? FindFirst("usuario").Value : ""; } }
        public string? idHospital { get { return Identity.IsAuthenticated ? FindFirst("idHospital").Value : ""; } }
        public string? idClient { get { return Identity.IsAuthenticated ? FindFirst("idClient").Value : ""; } }

    }
}
