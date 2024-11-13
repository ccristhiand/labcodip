using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class ResultadoCreateCommand
    {
        [Required(ErrorMessage = "IdReactivoDet requerido")]
        public string? IdReactivoDet { get; set; }

        [Required(ErrorMessage = "IdExamen requerido")]
        public string? IdExamen { get; set; }

        [Required(ErrorMessage = "IdLote requerido")]
        public string? IdLote { get; set; }

        [Required(ErrorMessage = "IdNivel requerido")]
        public string? IdNivel { get; set; }

        [Required(ErrorMessage = "Resultado requerido")]
        public string? Resultado { get; set; }

        public string? user { get; set; }

    }
}
