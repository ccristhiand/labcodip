using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class NivelCreateCommand
    {
        [Required(ErrorMessage = "IdReactivoDet requerido")]
        public string? IdReactivoDet { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        public string? user { get; set; }
    }
}
