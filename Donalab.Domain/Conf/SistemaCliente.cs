

using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class SistemaCliente : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdSistemaCliente { get; set; }

        [MaxLength(20)]
        public string? Server { get; set; }

        [MaxLength(50)]
        public string? BaseDeDatos { get; set; }

        [MaxLength(50)]
        public string? Usuario { get; set; }
        [MaxLength(50)]
        public string? Contrasena { get; set; }

        [MaxLength(4)]
        public string? IdTipoBaseDato { get; set; }

        [MaxLength(20)]
        public string? Nombre { get; set; }

        [MaxLength(4)]
        public string? Estado { get; set; }

    }
}
