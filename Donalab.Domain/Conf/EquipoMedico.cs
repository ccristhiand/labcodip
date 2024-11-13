

using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class EquipoMedico : Silac
    {
        [Key]
        [MaxLength(30)]
        public string? IdEquipoMedico { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(150)]
        public string? Detalle { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
