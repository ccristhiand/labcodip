using System.ComponentModel.DataAnnotations;

namespace Silac.Domain.Conf
{
    public class Perfil : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdPerfil { get; set; }
        [MaxLength(100)]
        public string? Nombre { get; set; }
        [MaxLength(4)]
        public string? Estado { get; set; }
    }
}
