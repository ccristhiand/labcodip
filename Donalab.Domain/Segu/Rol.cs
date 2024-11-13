using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Rol")]
    public class Rol : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdRol { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
