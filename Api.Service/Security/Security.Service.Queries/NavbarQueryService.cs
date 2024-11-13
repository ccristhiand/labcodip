using Common.Config;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System.Data;

namespace Security.Service.Queries
{
    public interface INavbarQueryService
    {
        Task<DataCollection<NavbarQuery>> Get();
        Task<NavbarQuery> Find(int id);
    }
    public class NavbarQueryService : INavbarQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public NavbarQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<NavbarQuery>> Get()
        {
            try
            {
                var navbar = await (from na in _dbContext.Navbar
                                    select new NavbarQuery
                                    {
                                        IdNavbar = na.IdNavbar,
                                        //Codigo = na.Codigo,
                                        //CodigoPadre = na.CodigoPadre,
                                        //CodigoHijo = na.CodigoHijo,
                                        //Url = na.Url,
                                        //Nombre = na.Nombre
                                    }).GetPagedAsync();

                return navbar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NavbarQuery> Find(int id)
        {
            try
            {
                var navbar = await (from na in _dbContext.Navbar
                                    where
                                    na.IdNavbar == id
                                    select new NavbarQuery
                                    {
                                        IdNavbar = na.IdNavbar,
                                        //Codigo = na.Codigo,
                                        //CodigoPadre = na.CodigoPadre,
                                        //CodigoHijo = na.CodigoHijo,
                                        //Url = na.Url,
                                        //Nombre = na.Nombre
                                    }).FirstOrDefaultAsync();

                return navbar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
