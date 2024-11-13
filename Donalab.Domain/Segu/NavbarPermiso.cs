
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("NavbarPermiso")]
    public class NavbarPermiso : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdNavbarPermiso { get; set; }

        [ForeignKey("Navbar")]
        public int? IdNavbar { get; set; }

        //[ForeignKey("Permiso")]
        //public string? IdPermiso { get; set; }

        [MaxLength(30)]
        public string? IdUsuario { get; set; }

        [MaxLength(30)]
        public string? IdPerfil { get; set; }

        public Navbar? Navbar { get; set; }

        //public Permiso? Permiso { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
