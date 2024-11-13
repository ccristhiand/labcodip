namespace Security.Service.Queries.Query
{
    public class NavbarRelacionRolMenu
    {
        public NavbarRelacionRolMenu()
        {
            ListaOpcionMenuValidar = new List<NavbarRelacionRolQuery>();
            ListaOpcionesMenu = new List<NavbarRelacionRolMenuQuery>();
        }
        public List<NavbarRelacionRolQuery> ListaOpcionMenuValidar { get; set; }
        public List<NavbarRelacionRolMenuQuery> ListaOpcionesMenu { get; set; }
    }

    public class NavbarRelacionRolQuery
    {
        public int? IdNavbar { get; set; }
        public string? label { get; set; }
        public string? icon { get; set; }
        public string? routerLink { get; set; }
        public int? idNavbarPrincipal { get; set; }
        public string? idRol { get; set; }
    }
    public class NavbarRelacionRolMenuQuery : NavbarRelacionRolQuery
    {
        public NavbarRelacionRolMenuQuery()
        {
            this.items = new List<NavbarRelacionRolQuery>();
        }
        public List<NavbarRelacionRolQuery>? items { get; set; }
    }
}
