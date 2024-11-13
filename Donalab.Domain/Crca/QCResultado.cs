using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Silac.Domain
{
    [Table("QCResultado")]
    public class QCResultado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? IdQCResultado { get; set; }

        [MaxLength(30)]
        public string? IdEquipoMedico { get; set; }

        [MaxLength(30)]
        public string? IdReactivoDet { get; set; }

        [MaxLength(30)]
        public string? IdExamen { get; set; }

        [MaxLength(30)]
        public string? IdLote { get; set; }

        [MaxLength(30)]
        public string? IdNivel { get; set; }

        [MaxLength(10)]
        public string? Resultado { get; set; }

        public DateTime? FechaResultado { get; set; }

        [MaxLength(10)]
        public string? HoraResultado { get; set; }

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
