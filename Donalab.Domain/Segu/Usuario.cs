using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Usuario")]
    public class Usuario : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdUsuario { get; set; }

        [ForeignKey("Persona")]
        public string? IdPersona { get; set; }

        [MaxLength(20)]
        public string? UserName { get; set; }

        [MaxLength(60)]
        public string? Password { get; set; }

        [MaxLength(20)]
        public string? CodExterno { get; set; }

        public byte Primer_acceso { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
        public bool? Permiso_Escritura { get; set; }
        public Persona? Persona { get; set; }
    }
}
