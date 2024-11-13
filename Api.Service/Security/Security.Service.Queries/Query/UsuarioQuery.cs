using Common.Utility;

namespace Security.Service
{
    public class UsuarioQuery
    {
        public UsuarioQuery()
        {
            ListaUsuarioRol = new List<string>();
            ListaUsuarioArea = new List<string>();
            ListaOpciones = new List<OptionQuery>();
            ListaRoles = new List<RolesQuery>();

            ListaLaboratorios = new List<LaboratorioQuery>();
            LaboratorioSelect = new List<LaboratorioQuery>();
        }

        public string? IdUsuario { get; set; }

        public int? Codigo { get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? CodExterno { get; set; }
        public string? Estado { get; set; }


        public string? IdPersona { get; set; }

        public string? IdTipoDocu { get; set; }

        public string? NroDocumento { get; set; }

        public string? ApePaterno { get; set; }

        public string? ApeMaterno { get; set; }

        public string? Nombre { get; set; }

        public string? NombreCompleto => ApePaterno + " " + ApeMaterno + " " + Nombre;

        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string? IdSexo { get; set; }
        public string? Color { get; set; }

        public bool? Permiso_Escritura { get; set; }
        public List<string> ListaUsuarioRol { get; set; }
        public List<string> ListaUsuarioArea { get; set; }
        public List<OptionQuery> ListaOpciones { get; set; }
        public List<RolesQuery> ListaRoles { get; set; }
        public List<LaboratorioQuery> ListaLaboratorios { get; set; }
        public List<LaboratorioQuery> LaboratorioSelect { get; set; }
    }

    public class RolesQuery
    {
        public string? Key { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public string? Parent { get; set; }
        public bool? PartialSelected { get; set; }
    }

    public class LaboratorioQuery
    {
        public LaboratorioQuery()
        {
            Children = new List<AreaQuery>();
        }
        public string? Key { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public List<AreaQuery> Children { get; set; }
    }

    public class AreaQuery
    {
        public string? Key { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public string? Parent { get; set; }
        public bool? PartialSelected { get; set; }
    }
}
