using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class ReactivoDetCreateCommand
    {
        public ReactivoDetCreateCommand()
        {
            ListaReactivoExamen = new List<ReactivoExamenCreateCommand>();
        }

        [Required(ErrorMessage = "IdReactivo requerido")]
        public string? IdReactivo { get; set; }

        public string? IdExamen { get; set; }

        public string? Nombre { get; set; }
        public string? user { get; set; }


        public List<ReactivoExamenCreateCommand> ListaReactivoExamen { get; set; }
    }
}
