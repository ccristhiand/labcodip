using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class OrigenCreateCommand
    {

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        public string? user { get; set; }

    }
}
