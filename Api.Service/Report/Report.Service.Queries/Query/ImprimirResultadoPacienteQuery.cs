namespace Report.Service.Queries.Query
{
    public class ImprimirResultadoPacienteQuery
    {
        public string? NombreCompleto { get; set; }
        public string? NroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Edad { get; set; }
        public string? Sexo { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string? Examen { get; set; }
        public string? Resultado { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Medico { get; set; }
        public string? RangoMostrar { get; set; }
        public string? NombreArea { get; set; }
        public string? NombrePerfil { get; set; }
        public string? Titulo { get; set; }
    }
}
