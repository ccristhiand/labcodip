namespace Configuration.Service.Queries.Query
{
    public class TablaMaestraQuery
    {
        public int IdTablaMaestra { get; set; }
        public string? Tabla { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Accion { get; set; }
        public string? Creado_por { get; set; }
        public DateTime? Fecha_creacion { get; set; }
        public string? Modificado_por { get; set; }
        public DateTime? Fecha_modificacion { get; set; }
    }
}
