using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Navbar")]
    public class Navbar : Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdNavbar { get; set; }

        [MaxLength(50)]
        public string? Label { get; set; }
        [MaxLength(20)]
        public string? icon { get; set; }
        public string? routerlink { get; set; }
        public string? TipoMenu { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
