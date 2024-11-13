using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class ServicioCreateCommand
    {

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }
        public string? user { get; set; }
    }
}
