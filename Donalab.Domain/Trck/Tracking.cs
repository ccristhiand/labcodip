using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class Tracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdTracking { get; set; }

        [MaxLength(30)]
        public string? IdTipoMuestra { get; set; }
        [MaxLength(30)]
        public string? IdOrden { get; set; }

        [MaxLength(30)]
        public string? NroOrden { get; set; }
        [MaxLength(30)]
        public string? IdOrdenExamen { get; set; }
        [MaxLength(30)]
        public string? IdExamen { get; set; }
        [MaxLength(50)]
        public string? DocumentoPaciente { get; set; }
        [MaxLength(40)]
        public string? NombrePaciente { get; set; }
        [MaxLength(40)]
        public string? ApellidoPaternoPaciente { get; set; }
        [MaxLength(40)]
        public string? ApellidoMaternoPaciente { get; set; }

        public bool? EstadoImpresionEtiqueta { get; set; }
        [MaxLength(30)]
        public string? UsuarioImpresionEtiqueta { get; set; }
        public DateTime? FechaImpresionEtiqueta { get; set; }
        public DateTime? FechaActualizacionImpresionEtiqueta { get; set; }

        public bool? EstadoLecturaEtiqueta { get; set; }
        public string? UsuarioLecturaEtiqueta { get; set; }
        public DateTime? FechaLecturaEtiqueta { get; set; }
        public DateTime? FechaActualizacionLecturaEtiqueta { get; set; }

        public bool? EstadoEnvioResultados { get; set; }
        public string? UsuarioEnvioResultados { get; set; }
        public DateTime? FechaEnvioResultados { get; set; }
        public DateTime? FechaActualizacionEnvioResultados { get; set; }

        public bool? EstadoPrevalidacion { get; set; }
        public string? UsuarioPrevalidacion { get; set; }
        public DateTime? FechaPrevalidacion { get; set; }
        public DateTime? FechaActualizacionPrevalidacion { get; set; }

        public bool? EstadoValidacion { get; set; }
        public string? UsuarioValidacion { get; set; }
        public DateTime? FechaValidacion { get; set; }
        public DateTime? FechaActualizacionValidacion { get; set; }

    }
}
