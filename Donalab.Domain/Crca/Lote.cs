using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Lote")]
    public class Lote : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdLote { get; set; }

        [MaxLength(30)]
        public string? IdReactivoDet { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public DateTime? FechaExpiracion { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
