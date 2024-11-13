using Common.Utility;

namespace Configuration.Service.EventHandlers.Commands
{
    public class TablaMaestraCommand : SilacCommand
    {
        public string? Tabla { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
    }
}
