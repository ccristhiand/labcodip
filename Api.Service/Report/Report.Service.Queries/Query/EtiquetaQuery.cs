namespace Report.Service.Queries.Query
{
    public class EtiquetaQuery
    {
        public string? IdOrden { get; set; }
        public string? Nombres { get; set; }
        public int? Edad { get; set; }
        public string? NroDocumento { get; set; }
        public string? HistoriaClinica { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FecNac { get; set; }
        public string? NroOrden { get; set; }
        public string? Examen { get; set; }
        public string? CodMuestra { get; set; }
        public string? Sexo { get; set; }
        public string? Prueba { get; set; }
        public byte[]? CodBarra { get; set; }
    }
}
