
using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class Procedencia : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdProcedencia { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
