using Common.Utility;

namespace Configuration.Service.Queries.Query
{

    public class AreaQuery
    {
        public AreaQuery()
        {
            ListaOpciones = new List<OptionQuery>();
        }
        public string? IdArea { get; set; }
        public int? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? NombreLaboratorio { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public string? Color { get; set; }
        public string? IdLaboratorio { get; set; }
        public List<OptionQuery> ListaOpciones { get; set; }
    }
}
