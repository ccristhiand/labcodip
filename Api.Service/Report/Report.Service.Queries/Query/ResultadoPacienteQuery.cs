namespace Report.Service.Queries.Query
{
    public class ResultadoPacienteQuery
    {
        public ResultadoPacienteQuery()
        {
            ListaResultadoPaciente = new List<ResultadoPaciente>();
            ListaFecha = new List<string>();
            ListaGraficoPaciente = new List<GraficoPaciente>();
        }

        public List<ResultadoPaciente> ListaResultadoPaciente { get; set; }
        public List<string> ListaFecha { get; set; }
        public List<GraficoPaciente> ListaGraficoPaciente { get; set; }
    }

    public class ResultadoPaciente
    {
        public string? IdPersona { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Sexo { get; set; }
        public string? NroDocumento { get; set; }
        public int? Edad { get; set; }
        public string? Abreviatura { get; set; }
        public string? Examen { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Resultado { get; set; }
        public string? FechaOrden { get; set; }
        public DateTime? FechaResultado { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? FechaUsuarioValMed { get; set; }
        public string? Color { get; set; }

        public string? StrFechaResultado => (FechaResultado == null) ? "" : FechaResultado.Value.ToString("dd/MM/yyyy");
        public string? StrFechaResultadoHora => (FechaResultado == null) ? "" : FechaResultado.Value.ToString("dd/MM/yyyy hh:mm:ss");

    }

    public class GraficoPaciente
    {
        public string? Label { get; set; }
        public List<string>? Data { get; set; }
        public string? BackgroundColor { get; set; }
        public string? BorderColor { get; set; }
        public string? Tension { get; set; }
        public string? PointRadius { get; set; }
    }
}
