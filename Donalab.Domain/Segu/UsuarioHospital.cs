using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("UsuarioHospital")]
    public class UsuarioHospital : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdUsuarioHospital { get; set; }

        [ForeignKey("Usuario")]
        public string? IdUsuario { get; set; }

        [ForeignKey("Hospital")]
        public string? IdHospital { get; set; }

        public Usuario? Usuario { get; set; }

        public Hospital? Hospital { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
