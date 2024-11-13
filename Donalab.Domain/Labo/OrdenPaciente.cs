using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class OrdenPaciente : Silac
    {
        [Key]
        [MaxLength(30)]
        public string? IdOrdenPaciente { get; set; }

        [MaxLength(10)]
        public string? HistoriaClinica { get; set; }

        [ForeignKey("Paciente")]
        [MaxLength(30)]
        public string? IdPaciente { get; set; }

        [ForeignKey("Orden")]
        [MaxLength(30)]
        public string? IdOrden { get; set; }

        [ForeignKey("Medico")]
        [MaxLength(30)]
        public string? IdMedico { get; set; }

        [ForeignKey("Procedencia")]
        [MaxLength(30)]
        public string? IdProcedencia { get; set; }

        [ForeignKey("Servicio")]
        [MaxLength(30)]
        public string? IdServicio { get; set; }

        [ForeignKey("Origen")]
        [MaxLength(30)]
        public string? IdOrigen { get; set; }


        [MaxLength(4)]
        public string? Estado { get; set; }

        public Paciente? Paciente { get; set; }
        public Orden? Orden { get; set; }
        public Medico? Medico { get; set; }
        public Procedencia? Procedencia { get; set; }
        public Servicio? Servicio { get; set; }
        public Origen? Origen { get; set; }
    }
}
