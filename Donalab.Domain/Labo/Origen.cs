
using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class Origen : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdOrigen { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
