

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    public class SistemaClienteExamen : ConfigAutoNumeric
    {

        [Key]
        [MaxLength(30)]
        public string? IdSistemaClienteExamen { get; set; }

        [MaxLength(30)]
        [ForeignKey("SistemaCliente")]
        public string? IdSistemaCliente { get; set; }

        [MaxLength(30)]
        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }

        [MaxLength(50)]
        public string? CodRecibe { get; set; }

        [MaxLength(50)]
        public string? CodDevuelve { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
        public SistemaCliente? SistemaCliente { get; set; }
        public Examen? Examen { get; set; }
    }
}
