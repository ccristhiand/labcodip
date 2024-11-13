using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Reactivo")]
    public class Reactivo : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        [Required]
        public string? IdReactivo { get; set; }

        [MaxLength(30)]
        public string? IdEquipoMedico { get; set; }

        [MaxLength(4)]
        public string? IdModo { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
