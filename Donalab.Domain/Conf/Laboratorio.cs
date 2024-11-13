using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Laboratorio")]
    public class Laboratorio : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdLaboratorio { get; set; }

        [MaxLength(5)]
        public string? CodigoLaboratorio { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
