using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class QCRangoCreateCommand
    {

        [Required(ErrorMessage = "IdReactivoDet requerido")]
        public string? IdReactivoDet { get; set; }

        [Required(ErrorMessage = "IdExamen requerido")]
        public string? IdExamen { get; set; }

        [Required(ErrorMessage = "IdLote requerido")]
        public string? IdLote { get; set; }

        [Required(ErrorMessage = "IdNivel requerido")]
        public string? IdNivel { get; set; }

        public decimal? RangoMinimo { get; set; }

        public decimal? RangoMedio { get; set; }

        public decimal? RangoMaximo { get; set; }

        public decimal? Desviacion { get; set; }

        public string? user { get; set; }
    }
}
