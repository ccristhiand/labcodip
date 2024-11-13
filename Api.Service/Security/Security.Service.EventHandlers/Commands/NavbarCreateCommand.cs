using Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace Security.Service.EventHandlers
{
    public class NavbarCreateCommand : SilacCommand
    {
        [Required(ErrorMessage = "CodigoPadre requerido")]
        public string? CodigoPadre { get; set; }

        public string? CodigoHijo { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        public string? Url { get; set; }
    }
}
