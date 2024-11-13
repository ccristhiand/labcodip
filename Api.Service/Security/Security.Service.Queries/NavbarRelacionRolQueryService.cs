using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Security.Service.Queries.Query;

namespace Security.Service.Queries
{
    public interface INavbarRelacionRolQueryService
    {
        Task<NavbarRelacionRolMenu> Get(string idrol);
    }
    public class NavbarRelacionRolQueryService : INavbarRelacionRolQueryService
    {
        private readonly PersistenceDatabase _dbContext;
        public NavbarRelacionRolQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NavbarRelacionRolMenu> Get(string idRol)
        {
            try
            {
                using (var dbContext = _dbContext)
                {
                    NavbarRelacionRolMenu navbarRelacionRolMenu = new NavbarRelacionRolMenu();
                    List<NavbarRelacionRolQuery> navbarRelacionRolQuery = new List<NavbarRelacionRolQuery>();
                    List<NavbarRelacionRolMenuQuery> navbarRelacionRolMenuQuery = new List<NavbarRelacionRolMenuQuery>();

                    navbarRelacionRolQuery = await (from NRR in dbContext.NavbarRelacionRol.AsNoTracking()
                                                    join NR in dbContext.NavbarRelacion.AsNoTracking() on NRR.IdNavbarRelacion equals NR.IdNavbarRelacion
                                                    join N in dbContext.Navbar.AsNoTracking() on NR.IdNavbarPrincipal equals N.IdNavbar
                                                    where NRR.IdRol.Contains(idRol)
                                                    select new NavbarRelacionRolQuery
                                                    {
                                                        icon = N.icon,
                                                        IdNavbar = N.IdNavbar,
                                                        label = N.Label,
                                                        routerLink = N.routerlink,
                                                        idNavbarPrincipal = NR.IdNavbarPrincipal,
                                                        idRol = NRR.IdRol
                                                    }
                                                  ).Distinct().AsNoTracking().ToListAsync();


                    var subMenu = await (from NRR in dbContext.NavbarRelacionRol.AsNoTracking()
                                         join NR in dbContext.NavbarRelacion.AsNoTracking() on NRR.IdNavbarRelacion equals NR.IdNavbarRelacion
                                         join N in dbContext.Navbar.AsNoTracking() on NR.IdNavbarSecundario equals N.IdNavbar
                                         select new NavbarRelacionRolQuery
                                         {
                                             icon = N.icon,
                                             IdNavbar = N.IdNavbar,
                                             label = N.Label,
                                             routerLink = N.routerlink,
                                             idNavbarPrincipal = NR.IdNavbarPrincipal,
                                             idRol = NRR.IdRol
                                         }).Distinct().AsNoTracking().ToListAsync();

                    foreach (var NavbarRelacionRolmenuQuery in navbarRelacionRolQuery)
                    {
                        NavbarRelacionRolMenuQuery itemNavbarRelacionRolMenuQuery = new NavbarRelacionRolMenuQuery();

                        itemNavbarRelacionRolMenuQuery.IdNavbar = NavbarRelacionRolmenuQuery.IdNavbar;
                        itemNavbarRelacionRolMenuQuery.label = NavbarRelacionRolmenuQuery.label;
                        itemNavbarRelacionRolMenuQuery.icon = NavbarRelacionRolmenuQuery.icon;
                        itemNavbarRelacionRolMenuQuery.routerLink = NavbarRelacionRolmenuQuery.routerLink;

                        itemNavbarRelacionRolMenuQuery.items = subMenu.Where(y => idRol.Contains(y.idRol!) && y.idNavbarPrincipal == itemNavbarRelacionRolMenuQuery.IdNavbar).ToList();

                        navbarRelacionRolMenuQuery.Add(itemNavbarRelacionRolMenuQuery);
                    }

                    navbarRelacionRolMenu.ListaOpcionMenuValidar.AddRange(navbarRelacionRolQuery);
                    navbarRelacionRolMenu.ListaOpcionMenuValidar.AddRange(subMenu);

                    navbarRelacionRolMenu.ListaOpcionMenuValidar = navbarRelacionRolMenu.ListaOpcionMenuValidar.Where(y => y.routerLink != null && y.routerLink != "" && y.routerLink != "/").ToList();

                    navbarRelacionRolMenu.ListaOpcionesMenu = navbarRelacionRolMenuQuery;

                    return navbarRelacionRolMenu;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
