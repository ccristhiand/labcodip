using Common.Utility;

namespace Configuration.Service.EventHandlers.Commands
{
    public class PersonaCommand : SilacCommand
    {
        public string? IdTipoDocu { get; set; }
        public string? NroDocumento { get; set; }
        public string? ApePaterno { get; set; }
        public string? ApeMaterno { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? IdSexo { get; set; }
        public string? Estado { get; set; }
    }
}
