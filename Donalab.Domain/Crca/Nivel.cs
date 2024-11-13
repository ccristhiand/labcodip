using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Nivel")]
    public class Nivel : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdNivel { get; set; }

        [MaxLength(30)]
        public string? IdReactivoDet { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
