using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class Orden : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdOrden { get; set; }

        [MaxLength(11)]
        public string? NroAtencion { get; set; }

        [MaxLength(11)]
        public string? NroOrden { get; set; }

        public DateTime? FechaOrden { get; set; }

        [MaxLength(10)]
        public string? HoraOrden { get; set; }

        [MaxLength(20)]
        public string? Cama { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
