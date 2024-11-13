public struct ReporteProcedure
{
    public const string spBuscarOrdenPorPaciente = "[rpt].[Reporte_BuscarOrdenPaciente]";
    public const string spBuscarPaciente = "[rpt].[Reporte_BuscarPaciente]";
    public const string spBuscarResultadoPaciente = "[rpt].[Reporte_BuscarResultadoPaciente]";
    public const string spImprimirResultadoPaciente = "[rpt].[Reporte_ImprimirResultadoPaciente]";

}

public struct EtiquetaProcedure
{
    public const string spImprimirEtiqueta = "[rpt].[Reporte_ImprimirEtiqueta]";
}

public struct UsuarioProcedure
{
    public const string spIniciarSession = "[segu].[Usuario_Credenciales]";
}

public struct TrackingAgregar
{
    public const string spTrackingAgregar = "[trak].[Tracking_Agregar]";
}

public struct DbConnectionTime
{
    public const int TimeOut = 120;
}