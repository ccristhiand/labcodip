using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class NavbarRelacion : Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdNavbarRelacion { get; set; }
        [ForeignKey("Navbar")]
        public int? IdNavbarPrincipal { get; set; }
        public int? IdNavbarSecundario { get; set; }
        public Navbar? Navbar { get; set; }
        public string Estado { get; set; }
    }
}
