using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Silac.Domain
{
    [Table("QCRango")]
    public class QCRango : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdQCRango { get; set; }

        [MaxLength(30)]
        public string? IdReactivoDet { get; set; }

        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }

        [ForeignKey("Lote")]
        public string? IdLote { get; set; }

        [ForeignKey("Nivel")]
        public string? IdNivel { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? RangoMinimo { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? RangoMedio { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? RangoMaximo { get; set; }

        [Column(TypeName = "decimal(18, 6)")]
        public decimal? Desviacion { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }



        public Examen? Examen { get; set; }
        public Lote? Lote { get; set; }
        public Nivel? Nivel { get; set; }
    }
}
