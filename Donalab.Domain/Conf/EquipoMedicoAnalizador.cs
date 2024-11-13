
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class EquipoMedicoAnalizador : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdEquipoMedicoAnalizador { get; set; }

        [ForeignKey("EquipoMedico")]
        [MaxLength(30)]
        public string? IdEquipoMedico { get; set; }

        [MaxLength(10)]
        public string? SerialPuerto { get; set; }
        public int? SerialBaudrate { get; set; }
        public int? SerialDataBit { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
        public EquipoMedico? EquipoMedico { get; set; }
    }
}
