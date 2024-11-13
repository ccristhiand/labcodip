using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class ReactivoCreateCommand
    {

        [Required(ErrorMessage = "IdEquipoMedico requerido")]
        public string? IdEquipoMedico { get; set; }

        [Required(ErrorMessage = "IdModo requerido")]
        public string? IdModo { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }
        public string? user { get; set; }

    }
}
