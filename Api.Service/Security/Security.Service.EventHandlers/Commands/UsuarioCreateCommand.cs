using System.ComponentModel.DataAnnotations;

namespace Security.Service.EventHandlers
{
    public class UsuarioCreateCommand
    {
        public UsuarioCreateCommand()
        {
            ListaUsuarioRol = new List<string>();
            ListaUsuarioArea = new List<string>();
        }



        [Required(ErrorMessage = "UserName requerido")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password requerido")]
        public string? Password { get; set; }

        public string? CodExterno { get; set; }

        [Required(ErrorMessage = "Rol requerido")]
        public List<string> ListaUsuarioRol { get; set; }

        [Required(ErrorMessage = "Area requerido")]
        public List<string> ListaUsuarioArea { get; set; }
        public string? user { get; set; }

        public string? IdPersona { get; set; }

        [Required(ErrorMessage = "IdTipoDocu requerido")]
        public string? IdTipoDocu { get; set; }

        [Required(ErrorMessage = "NroDocumento requerido")]
        public string? NroDocumento { get; set; }

        [Required(ErrorMessage = "ApePaterno requerido")]
        public string? ApePaterno { get; set; }

        [Required(ErrorMessage = "ApeMaterno requerido")]
        public string? ApeMaterno { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Permiso Escritura requerido")]
        public bool? Permiso_Escritura { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? IdSexo { get; set; }
    }

    public class LoginCreateCommand
    {
        [Required(ErrorMessage = "usuario requerido")]
        public string? usuario { get; set; }

        [Required(ErrorMessage = "password requerido")]
        public string? password { get; set; }

        [Required(ErrorMessage = "domain requerido")]
        public string? domain { get; set; }
    }
}
