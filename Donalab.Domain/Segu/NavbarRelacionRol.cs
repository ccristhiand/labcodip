using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class NavbarRelacionRol : Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNavbarRelacionRol { get; set; }
        [ForeignKey("NavbarRelacion")]
        public int IdNavbarRelacion { get; set; }

        [ForeignKey("Rol")]
        [MaxLength(30)]
        public string? IdRol { get; set; }

        public string? Estado { get; set; }

        public NavbarRelacion? navbarRelacion { get; set; }
        public Rol? Rol { get; set; }


    }
}
