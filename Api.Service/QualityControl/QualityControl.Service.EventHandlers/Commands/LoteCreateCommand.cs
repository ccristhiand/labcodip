using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class LoteCreateCommand
    {
        [Required(ErrorMessage = "IdReactivoDet requerido")]
        public string? IdReactivoDet { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "FechaExpiracion requerido")]
        public DateTime? FechaExpiracion { get; set; }

        public string? user { get; set; }

    }
}
