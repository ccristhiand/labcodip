using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("UsuarioArea")]
    public class UsuarioArea : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdUsuarioArea { get; set; }

        [ForeignKey("Usuario")]
        [MaxLength(30)]
        public string? IdUsuario { get; set; }

        [ForeignKey("Area")]
        [MaxLength(30)]
        public string? IdArea { get; set; }

        public Usuario? Usuario { get; set; }

        public Area? Area { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
