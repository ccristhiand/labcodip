using Common.Utility;

namespace QualityControl.Service
{
    public class ReactivoQuery
    {
        public ReactivoQuery()
        {
            ListaOpciones = new List<OptionQuery>();
        }
        public string? IdReactivo { get; set; }

        public int? Codigo { get; set; }

        public string? IdEquipoMedico { get; set; }

        public string? IdModo { get; set; }

        public string? IdLaboratorio { get; set; }

        public string? IdArea { get; set; }

        public string? Nombre { get; set; }

        public string? NombreEquipo { get; set; }
        public string? NombreLaboratorio { get; set; }
        public string? NombreArea { get; set; }

        public string? Estado { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
    }
}
