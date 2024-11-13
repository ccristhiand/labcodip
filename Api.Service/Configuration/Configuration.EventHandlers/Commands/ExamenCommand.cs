namespace Configuration.Service.EventHandlers.Commands
{
    public class ExamenCommand
    {
        public ExamenCommand()
        {
            ListaExamenRango = new List<ExamenRangoCommand>();
        }
        public string? IdArea { get; set; }
        public string? IdTipoMuestra { get; set; }
        public string? Calculado { get; set; }
        public string? Abreviatura { get; set; }
        public string? Nombre { get; set; }
        public string? UnidadMedida { get; set; }
        public int? CantidadDecimal { get; set; }
        public int? Orden { get; set; }
        public string? TipoCongRango { get; set; }
        public string? Estado { get; set; }
        public string? RangoMostrar { get; set; }
        public string? user { get; set; }
        public string? Color { get; set; }
        public int? TiempoTrackingMin { get; set; }

        public List<ExamenRangoCommand> ListaExamenRango { get; set; }
    }

    public class ExamenRangoCommand
    {
        public string? IdExamen { get; set; }
        public string? IdSexo { get; set; }
        public int? EdadInicio { get; set; }
        public int? EdadFinal { get; set; }
        public string? ValorMinimo { get; set; }
        public string? ValorMaximo { get; set; }
        public string? IdInterpretado { get; set; }
        public string? SigComparativo { get; set; }
        public string? Estado { get; set; }
        public string? IdExamenRango { get; set; }
        public string? user { get; set; }
    }
}
