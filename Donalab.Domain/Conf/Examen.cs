using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class Examen : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdExamen { get; set; }

        [ForeignKey("TipoMuestra")]
        [MaxLength(30)]
        public string? IdTipoMuestra { get; set; }

        [ForeignKey("Area")]
        [MaxLength(30)]
        public string? IdArea { get; set; }


        [MaxLength(30)]
        public string? Calculado { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Abreviatura { get; set; }

        [MaxLength(150)]
        [Required]
        public string? Nombre { get; set; }

        [MaxLength(50)]
        public string? UnidadMedida { get; set; }

        public int? CantidadDecimal { get; set; }

        public int? Orden { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public int? TiempoTrackingMin { get; set; }

        [MaxLength(300)]
        public string? RangoMostrar { get; set; }

        [MaxLength(4)]
        public string? TipoCongRango { get; set; }

        [MaxLength(30)]
        public string? Color { get; set; }

        public TipoMuestra? TipoMuestra { get; set; }
        public Area? Area { get; set; }

    }
}
