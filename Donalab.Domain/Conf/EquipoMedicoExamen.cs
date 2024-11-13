
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class EquipoMedicoExamen : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdEquipoMedicoExamen { get; set; }

        [MaxLength(30)]
        [ForeignKey("EquipoMedico")]
        public string? IdEquipoMedico { get; set; }

        [MaxLength(30)]
        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }

        [MaxLength(50)]
        public string? CodRecibe { get; set; }

        [MaxLength(50)]
        public string? CodDevuelve { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

        public EquipoMedico? EquipoMedico { get; set; }
        public Examen? Examen { get; set; }

    }
}
