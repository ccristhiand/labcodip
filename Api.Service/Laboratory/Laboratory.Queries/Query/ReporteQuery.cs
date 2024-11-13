using Common.Utility;

namespace Laboratory.Service
{
    public class ReporteQuery
    {
        public ReporteQuery()
        {
            ListaTipoMuestra = new List<TipoMuestraQuery>();
            ListaOpciones = new List<OptionQuery>();
        }

        public List<TipoMuestraQuery> ListaTipoMuestra { get; set; }
        public List<OptionQuery> ListaOpciones { get; set; }
    }

    public class TipoMuestraQuery
    {
        public string? Key { get; set; }
        public string? Label { get; set; }
        public string? Icon { get; set; }
        public string? Parent { get; set; }
        public bool? PartialSelected { get; set; }
    }
}
