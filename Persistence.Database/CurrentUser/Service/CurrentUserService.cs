using Microsoft.AspNetCore.Http;
using Persistence.Database.CurrentUser.Claims;

namespace Persistence.Database.CurrentUser.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly FrontEndUser _currentUser;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                var principal = httpContextAccessor.HttpContext?.User;
                _currentUser = new FrontEndUser(principal);
            }
        }


        public string Usuario => _currentUser == null! ? "" : _currentUser.usuario;
        public string IdHospital => _currentUser == null! ? "" : _currentUser.idHospital!;
        public string IdClient => _currentUser == null! ? "" : _currentUser.idClient!;
    }
}
