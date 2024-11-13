using System.ComponentModel.DataAnnotations;

namespace Silac.Domain
{
    public class Silac : ConfigAutoNumeric
    {

        [Required(ErrorMessage = "IdLaboratorio requerido")]
        [MaxLength(30)]
        public string? IdLaboratorio { get; set; }

        [Required(ErrorMessage = "IdArea requerido")]
        [MaxLength(30)]
        public string? IdArea { get; set; }

    }
}
