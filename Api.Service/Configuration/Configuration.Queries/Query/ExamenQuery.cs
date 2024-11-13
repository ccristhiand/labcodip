using Common.Utility;

namespace Configuration.Service
{
    public class ExamenQuery
    {
        public ExamenQuery()
        {
            ListaOpciones = new List<OptionQuery>();
            ListaExamenRango1 = new List<ExamenRangoQuery>();
            ListaExamenRango2 = new List<ExamenRangoQuery>();
            ListaExamenRango3 = new List<ExamenRangoQuery>();
            ListaExamenRango4 = new List<ExamenRangoQuery>();

        }
        public string? IdExamen { get; set; }
        public int? Codigo { get; set; }
        public string? IdTipoMuestra { get; set; }
        public string? NombreTipoMuestra { get; set; }
        public string? IdArea { get; set; }
        public string? NombreArea { get; set; }
        public string? Calculado { get; set; }
        public string? Abreviatura { get; set; }
        public string? Nombre { get; set; }
        public string? UnidadMedida { get; set; }
        public int? CantidadDecimal { get; set; }
        public int? Orden { get; set; }
        public string? Estado { get; set; }
        public string? Color { get; set; }
        public int? TiempoTrackingMin { get; set; }
        public string? RangoMostrar { get; set; }
        public string? TipoCongRango { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
        public List<ExamenRangoQuery> ListaExamenRango1 { get; set; }
        public List<ExamenRangoQuery> ListaExamenRango2 { get; set; }
        public List<ExamenRangoQuery> ListaExamenRango3 { get; set; }
        public List<ExamenRangoQuery> ListaExamenRango4 { get; set; }

    }

    public class ExamenRangoQuery
    {
        public string? IdExamenRango { get; set; }
        public string? IdExamen { get; set; }
        public int? EdadInicio { get; set; }
        public int? EdadFinal { get; set; }
        public string? ValorMinimo { get; set; }
        public string? ValorMaximo { get; set; }
        public string? SigComparativo { get; set; }
        public string? IdInterpretado { get; set; }
        public string? Interpretado { get; set; }
        public string? Estado { get; set; }
        public string? Color { get; set; }
    }
}
