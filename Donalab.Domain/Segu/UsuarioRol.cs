using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("UsuarioRol")]
    public class UsuarioRol : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdUsuarioRol { get; set; }

        [ForeignKey("Usuario")]
        public string? IdUsuario { get; set; }

        [ForeignKey("Rol")]
        public string? IdRol { get; set; }

        public Usuario? Usuario { get; set; }

        public Rol? Rol { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
