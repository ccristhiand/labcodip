using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silac.Domain.Conf
{
    public class PerfilExamen : ConfigAutoNumeric
    {
        [Key]
        [MaxLength(30)]
        public string? IdPerfilExamen { get; set; }
        [ForeignKey("Perfil")]
        public string? IdPerfil { get; set; }
        [ForeignKey("Examen")]
        public string? IdExamen { get; set; }
        [MaxLength(4)]
        public string? Estado { get; set; }
        public Perfil? Perfil { get; set; }
        public Examen? Examen { get; set; }

    }
}
