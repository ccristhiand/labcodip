using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Permiso")]
    public class Permiso : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdPermiso { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
