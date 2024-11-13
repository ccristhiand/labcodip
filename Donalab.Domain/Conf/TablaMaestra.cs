using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("TablaMaestra")]
    public class TablaMaestra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTablaMaestra { get; set; }

        [MaxLength(50)]
        public string? Tabla { get; set; }

        [MaxLength(4)]
        public string? Codigo { get; set; }
        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Accion { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }

        [MaxLength(20)]
        public string? Creado_por { get; set; }

        public DateTime? Fecha_creacion { get; set; }

        [MaxLength(50)]
        public string? Modificado_por { get; set; }

        public DateTime? Fecha_modificacion { get; set; }
    }
}
