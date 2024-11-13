namespace Tracking.Service.Queries.Query
{
    public class TrackingQuery
    {
        public int? IdTracking { get; set; }
        public string? CodigoOrden { get; set; }
        public string? ExamenName { get; set; }
        public string? DocumentoPaciente { get; set; }
        public string? NombreCompletoPaciente { get; set; }
        public string? TipoMuestra { get; set; }

        public bool? EstadoImpresionEtiqueta { get; set; }
        public string? UsuarioImpresionEtiqueta { get; set; }
        public DateTime? FechaImpresionEtiqueta { get; set; }

        public bool? EstadoEnvioResultados { get; set; }
        public string? UsuarioEnvioResultados { get; set; }
        public DateTime? FechaEnvioResultados { get; set; }

        public bool? EstadoValidacion { get; set; }
        public string? UsuarioValidacion { get; set; }
        public DateTime? FechaValidacion { get; set; }
        public int? TimeTrackingMin { get; set; }


        public int? MinutosInicioValidacion { get; set; }
        public int? SegundosInicioValidacion { get; set; }
        public int? MinutosInicioActual { get; set; }
        public int? SegundosInicioActual { get; set; }
        public EstadoTracking Estadotracking { get; set; }
        public EstadoColortracking EstadoColortracking { get; set; }


        //public TiempoDeTracking? TiempoDeTracking { get; set; }
    }
    public class TiempoDeTracking
    {
        public int? TimeTrackingMin { get; set; }
        public int? MinutosInicioValidacion { get; set; }
        public int? SegundosInicioValidacion { get; set; }
        public int? MinutosInicioActual { get; set; }
        public int? SegundosInicioActual { get; set; }
        public EstadoTracking Estadotracking { get; set; }
        public EstadoColortracking EstadoColortracking { get; set; }

    }

    public enum EstadoTracking
    {
        Proceso,
        Procesado,
        FueraTiempo,
        SinAcciones
    }
    public enum EstadoColortracking
    {
        Yellow,
        Green,
        Red,
        Gray
    }
}
