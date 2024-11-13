

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class ExamenRango : Config
    {
        [Key]
        [MaxLength(30)]
        public string? IdExamenRango { get; set; }

        [ForeignKey("Examen")]
        [MaxLength(30)]
        public string? IdExamen { get; set; }

        public int? EdadInicio { get; set; }

        public int? EdadFinal { get; set; }

        [MaxLength(50)]
        public string? ValorMaximo { get; set; }

        [MaxLength(50)]
        public string? SigComparativo { get; set; }

        [MaxLength(50)]
        public string? ValorMinimo { get; set; }

        [MaxLength(4)]
        public string? IdInterpretado { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public Examen? Examen { get; set; }
    }
}
