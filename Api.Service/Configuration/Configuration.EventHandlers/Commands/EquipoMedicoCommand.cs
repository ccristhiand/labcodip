using Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Service.EventHandlers.Commands
{
    public class EquipoMedicoCommand : SilacCommand
    {
        public EquipoMedicoCommand()
        {
            ListaEquipoMedicoAnalizador = new List<EquipoMedicoAnalizadorCommand>();
        }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }

        public string? Detalle { get; set; }
        public string? Estado { get; set; }

        public List<EquipoMedicoAnalizadorCommand> ListaEquipoMedicoAnalizador { get; set; }
    }
    public class EquipoMedicoAnalizadorCommand
    {

        public string? IdEquipoMedico { get; set; }
        public string? SerialPuerto { get; set; }
        public int? SerialBaudrate { get; set; }
        public int? SerialDataBit { get; set; }
        public string? Estado { get; set; }

    }
}
