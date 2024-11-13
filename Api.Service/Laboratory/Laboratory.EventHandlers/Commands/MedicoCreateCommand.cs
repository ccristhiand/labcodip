using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class MedicoCreateCommand
    {

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

        public DateTime? FechaNacimiento { get; set; }

        public string? IdSexo { get; set; }

        public string? user { get; set; }
    }
}
