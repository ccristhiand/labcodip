using Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace Security.Service.EventHandlers
{
    public class RolCreateCommand : SilacCommand
    {
        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }
    }
}
