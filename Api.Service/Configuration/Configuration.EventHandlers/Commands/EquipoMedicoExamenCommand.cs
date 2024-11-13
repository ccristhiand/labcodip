namespace Configuration.Service.EventHandlers.Commands
{
    public class EquipoMedicoExamenCommand
    {
        public EquipoMedicoExamenCommand()
        {
            ListaIdExamen = new List<string>();
        }
        public List<string>? ListaIdExamen { get; set; }
        public string? IdEquipoMedico { get; set; }
        public string? user { get; set; }
        public string? CodRecibe { get; set; }
        public string? CodDevuelve { get; set; }
        public string? tipoCodigo { get; set; }
    }
}
