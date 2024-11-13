
using System.ComponentModel.DataAnnotations;


namespace Silac.Domain
{
    public class TipoMuestra : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdTipoMuestra { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Nombre { get; set; }

        [MaxLength(150)]
        public string? Descripcion { get; set; }

        [MaxLength(4)]
        public string? CodigoTipoMuestra { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
