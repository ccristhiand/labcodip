using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("ReactivoExamen")]
    public class ReactivoExamen : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdReactivoExamen { get; set; }

        [ForeignKey("ReactivoDet")]
        public string? IdReactivoDet { get; set; }

        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public ReactivoDet? ReactivoDet { get; set; }
        public Examen? Examen { get; set; }
    }
}
