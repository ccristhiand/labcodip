using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class UsuarioRolPermiso : Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioRolPermiso { get; set; }
        [ForeignKey("UsuarioRol")]
        public string? IdUsuarioRol { get; set; }
        [ForeignKey("Permiso")]
        public string? IdPermiso { get; set; }
        [MaxLength(4)]
        public string? Estado { get; set; }

        public UsuarioRol? UsuarioRol { get; set; }
        public Permiso? Permiso { get; set; }
    }
}
