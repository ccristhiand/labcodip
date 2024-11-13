namespace Report.Service.Queries.Query
{
    public class OrdenPorPacienteQuery
    {
        public string? IdPersona { get; set; }
        public string? NroOrden { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NroDocumento { get; set; }
        public string? HistoriaClinica { get; set; }
        public string? ApePaterno { get; set; }
        public string? ApeMaterno { get; set; }
        public string? Nombre { get; set; }
        public string? Abreviatura { get; set; }
        public string? NombreExamen { get; set; }
        public string? Resultado { get; set; }
        public string? UnidadMedida { get; set; }
        public string? FechaOrden { get; set; }
        public DateTime? FechaResultado { get; set; }
        public string? FechaUsuarioValMed { get; set; }

        public string? StrFechaResultado => (FechaResultado == null) ? "" : FechaResultado.Value.ToString("dd/MM/yyyy");
        public string? StrFechaResultadoHora => (FechaResultado == null) ? "" : FechaResultado.Value.ToString("dd/MM/yyyy hh:mm:ss");
        public string? NombreCompleto => ApePaterno + " " + ApeMaterno + " " + Nombre;

    }
}
