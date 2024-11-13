using Common.Config;
using Persistence.Database;

namespace Security.Service.Queries
{
    public interface INavbarPermisoQueryService
    {
        Task<DataCollection<NavbarPermisoQuery>> Get();
    }
    public class NavbarPermisoQueryService : INavbarPermisoQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public NavbarPermisoQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<NavbarPermisoQuery>> Get()
        {
            //try
            //{
            //    var navbar = await (from na in _dbContext.NavbarPermiso
            //                        select new NavbarPermisoQuery
            //                        {

            //                        }).GetPagedAsync();

            //    return navbar;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }
    }
}
