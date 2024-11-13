using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Persona")]
    public class Persona : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdPersona { get; set; }

        [MaxLength(4)]
        public string? IdTipoDocu { get; set; }

        [MaxLength(15)]
        public string? NroDocumento { get; set; }

        [MaxLength(20)]
        public string? ApePaterno { get; set; }

        [MaxLength(20)]
        public string? ApeMaterno { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(4)]
        public string? IdSexo { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
