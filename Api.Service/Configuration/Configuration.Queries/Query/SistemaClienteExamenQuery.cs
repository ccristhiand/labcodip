using Silac.Domain;

namespace Configuration.Service.Queries.Query
{
    public class SistemaClienteExamenQuery
    {
        public string? IdSistemaClienteExamen { get; set; }
        public string? IdSistemaCliente { get; set; }
        public string? IdExamen { get; set; }
        public string? CodRecibe { get; set; }
        public string? CodDevuelve { get; set; }
        public string? NombreExamen { get; set; }
        public string? NombreArea { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Estado { get; set; }
        public SistemaCliente? SistemaCliente { get; set; }
    }
}
