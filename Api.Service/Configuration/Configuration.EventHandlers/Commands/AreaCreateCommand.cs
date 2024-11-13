
using Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Service.EventHandlers.Commands
{
    public class AreaCreateCommand : ConfigCommandArea
    {
        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
