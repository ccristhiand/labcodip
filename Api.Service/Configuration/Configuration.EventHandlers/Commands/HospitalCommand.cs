using System.ComponentModel.DataAnnotations;

namespace Configuration.Service.EventHandlers.Commands
{
    public class HospitalCommand
    {
        public string? CodigoHospital { get; set; }

        [Required(ErrorMessage = "IdLaboratorio requerido")]
        public string? Nombre { get; set; }
        public string? Titulo { get; set; }
        public string? SubTitulo { get; set; }
        public string? PiePagina { get; set; }

        [Required(ErrorMessage = "IdLaboratorio requerido")]
        public string? Direccion { get; set; }
        //public byte? Foto { get; set; }
        public string? user { get; set; }
    }
}
