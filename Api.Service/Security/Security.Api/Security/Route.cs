namespace Security
{
    public class ApiUrl
    {
        public const string Api = "api/";
    }

    public class Routes
    {
        public const string Base = ApiUrl.Api + "base";
        public const string Usuario = ApiUrl.Api + "login";
        public const string Rol = ApiUrl.Api + "rol";
        public const string Permiso = ApiUrl.Api + "permiso";
        public const string Navbar = ApiUrl.Api + "navbar";
        public const string NavbarRelacionRol = ApiUrl.Api + "navbarrelacionrol";
        public const string ValidacionPermiso = ApiUrl.Api + "validacionpermiso";
    }
}
