using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("ReactivoDet")]
    public class ReactivoDet : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        [Required]
        public string? IdReactivoDet { get; set; }

        [ForeignKey("Reactivo")]
        public string? IdReactivo { get; set; }

        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public Reactivo? Reactivo { get; set; }
        public Examen? Examen { get; set; }
    }
}
