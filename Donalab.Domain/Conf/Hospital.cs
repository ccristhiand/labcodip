using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain
{
    [Table("Hospital")]
    public class Hospital : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdHospital { get; set; }

        [MaxLength(5)]
        public string? CodigoHospital { get; set; }

        [MaxLength(50)]
        public string? Nombre { get; set; }

        [MaxLength(200)]
        public string? Titulo { get; set; }

        [MaxLength(200)]
        public string? SubTitulo { get; set; }

        [MaxLength(200)]
        public string? PiePagina { get; set; }

        [MaxLength(200)]
        public string? Direccion { get; set; }

        public byte? Foto { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
