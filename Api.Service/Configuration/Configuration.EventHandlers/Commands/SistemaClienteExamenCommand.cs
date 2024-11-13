namespace Configuration.Service.EventHandlers.Commands
{
    public class SistemaClienteExamenCommand
    {
        public SistemaClienteExamenCommand()
        {
            ListaIdExamen = new List<string>();
        }

        public List<string>? ListaIdExamen { get; set; }
        public string? IdSistemaCliente { get; set; }
        public string? CodRecibe { get; set; }
        public string? CodDevuelve { get; set; }
        public string? Estado { get; set; }
        public string? user { get; set; }
        public string? tipoCodigo { get; set; }
    }
}
