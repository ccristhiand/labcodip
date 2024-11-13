using Common.Utility;

namespace Configuration.Service.Queries.Query
{
    public class SistemaClienteQuery
    {
        public SistemaClienteQuery()
        {
            ListaOpciones = new List<OptionQuery>();
        }
        public string? IdSistemaCliente { get; set; }
        public int? Codigo { get; set; }
        public string? Server { get; set; }
        public string? BaseDeDatos { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
        public string? IdTipoBaseDato { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }
        public string? Color { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
    }
}
