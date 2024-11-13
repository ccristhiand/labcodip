using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Area")]
    public class Area : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdArea { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(150)]
        public string? Descripcion { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        [ForeignKey("Laboratorio")]
        [Required]
        public string? IdLaboratorio { get; set; }

        public Laboratorio? Laboratorio { get; set; }
    }
}
