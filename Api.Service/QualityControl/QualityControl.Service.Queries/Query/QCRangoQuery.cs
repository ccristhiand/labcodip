using Common.Utility;

namespace QualityControl.Service
{
    public class QCRangoQuery
    {
        public QCRangoQuery()
        {
            ListaOpciones = new List<OptionQuery>();
            ListaQCRangoDet = new List<QCRangoDetQuery>();
        }

        public string? NombreControl { get; set; }
        public string? IdLote { get; set; }

        public string? IdNivel { get; set; }

        public string? FechaExpiracion { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
        public List<QCRangoDetQuery> ListaQCRangoDet { get; set; }
    }

    public class QCRangoDetQuery
    {
        public string? IdReactivoDet { get; set; }

        public string? IdQCRango { get; set; }

        public string? IdExamen { get; set; }

        public string? IdLote { get; set; }

        public string? IdNivel { get; set; }

        public decimal? RangoMinimo { get; set; }

        public decimal? RangoMedio { get; set; }

        public decimal? RangoMaximo { get; set; }

        public decimal? Desviacion { get; set; }

        public string? NombreExamen { get; set; }
    }
}
