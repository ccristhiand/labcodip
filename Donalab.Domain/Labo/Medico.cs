
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class Medico : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdMedico { get; set; }

        [ForeignKey("Persona")]
        [MaxLength(30)]
        public string? IdPersona { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public Persona? Persona { get; set; }
    }
}
