
using Silac.Domain.Conf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class OrdenExamen : Silac
    {
        [Key]
        [MaxLength(30)]

        public string? IdOrdenExamen { get; set; }

        [ForeignKey("Orden")]
        [MaxLength(30)]
        public string? IdOrden { get; set; }

        [ForeignKey("Examen")]
        [MaxLength(30)]
        public string? IdExamen { get; set; }
        [ForeignKey("Perfil")]
        [MaxLength(30)]
        public string? Idperfil { get; set; }
        [MaxLength(100)]
        public string? NombrePerfil { get; set; }

        public DateTime? FechaResultado { get; set; }

        [MaxLength(20)]
        public string? Resultado { get; set; }

        [MaxLength(200)]
        public string? Observacion { get; set; }

        [MaxLength(30)]
        public string? UsuarioValMed { get; set; }
        public DateTime? FechaUsuarioValMed { get; set; }

        [MaxLength(4)]
        public string? EstadoUsuarioMed { get; set; }

        [MaxLength(30)]
        public string? UsuarioValTec { get; set; }
        public DateTime? FechaUsuarioValTec { get; set; }

        [MaxLength(4)]
        public string? EstadoUsuarioTec { get; set; }
        public int? SwtResultsSGSS { get; set; }
        public int? IntentoSGSS { get; set; }
        public string? MensajeSGSS { get; set; }

        [MaxLength(50)]
        public string? IdItem { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
        public Orden? Orden { get; set; }
        public Examen? Examen { get; set; }
        public Perfil? Perfil { get; set; }

    }
}
