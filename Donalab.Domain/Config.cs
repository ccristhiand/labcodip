using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{


    public class ConfigAutoNumeric
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int? Codigo { get; set; }

        [MaxLength(4)]
        public string? Accion { get; set; }

        [MaxLength(20)]
        public string? Creado_por { get; set; }
        public DateTime? Fecha_creacion { get; set; }

        [MaxLength(50)]
        public string? Modificado_por { get; set; }

        public DateTime? Fecha_modificacion { get; set; }

    }


    public class Config
    {
        [MaxLength(4)]
        public string? Accion { get; set; }

        [MaxLength(20)]
        public string? Creado_por { get; set; }
        public DateTime? Fecha_creacion { get; set; }

        [MaxLength(50)]
        public string? Modificado_por { get; set; }

        public DateTime? Fecha_modificacion { get; set; }

    }
}
