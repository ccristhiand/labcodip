using Common.Utility;

namespace QualityControl.Service
{
    public class QCResultadoQuery
    {
        public QCResultadoQuery()
        {
            ListaOpciones = new List<OptionQuery>();
            ListaConfigRangoSilac = new List<ConfigRangoQuery>();
            ListaConfigRangoEquipo = new List<ConfigRangoQuery>();
            ListaData = new List<ResultadoQuery>();
            listaResultadoSilac = new List<string?>();
            ListaResultadoEquipo = new List<string?>();
            ListaDia = new List<string?>();
        }

        public decimal? RangoMedioSilac { get; set; }
        public decimal? DesviacionSilac { get; set; }
        public decimal? RangoMedioEquipo { get; set; }
        public decimal? DesviacionEquipo { get; set; }
        public List<OptionQuery> ListaOpciones { get; set; }
        public List<ConfigRangoQuery> ListaConfigRangoSilac { get; set; }
        public List<ConfigRangoQuery> ListaConfigRangoEquipo { get; set; }
        public List<ResultadoQuery> ListaData { get; set; }
        public List<string?> listaResultadoSilac { get; set; }
        public List<string?> ListaResultadoEquipo { get; set; }
        public List<string?> ListaDia { get; set; }
    }

    public class ResultadoQuery
    {
        public string? Resultado { get; set; }
        public DateTime? FechaResultado { get; set; }
        public string? StrFechaResultado => (FechaResultado == null) ? "" : FechaResultado.Value.ToString("dd/MM/yyyy");
        public string? HoraResultado { get; set; }
        public string? FueraLimite { get; set; }
    }

    public class RangoQuery
    {
        public decimal? RangoMaximo { get; set; }
        public decimal? RangoMinimo { get; set; }
        public decimal? RangoMedio { get; set; }
        public decimal? Desviacion { get; set; }
    }

    public class ConfigRangoQuery
    {
        public string? Transaction { get; set; }
        public decimal? Amount { get; set; }
        public string? Icon { get; set; }
        public string? IconColor { get; set; }
        public string? AmountColor { get; set; }
    }

}
