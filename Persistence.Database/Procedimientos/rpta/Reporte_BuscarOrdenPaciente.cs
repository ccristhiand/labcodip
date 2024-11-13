namespace Persistence.Database.Procedimientos
{
    public class Reporte_BuscarOrdenPaciente
    {
        public string SP_Reporte_BuscarOrdenPaciente { get; } =
            @"CREATE OR ALTER   PROCEDURE [rpt].[Reporte_BuscarOrdenPaciente]
				@valor VARCHAR(50),
				@fechaInicio date,
				@fechaFin date
				AS
				BEGIN
					SELECT ord.NroOrden, per.IdTipoDocu TipoDocumento, per.NroDocumento, opa.HistoriaClinica,
					per.ApePaterno, per.ApeMaterno, per.Nombre, exa.Abreviatura, exa.Nombre NombreExamen, oe.Resultado, exa.UnidadMedida, ord.FechaOrden, oe.FechaUsuarioValMed,exa.Color
					FROM[labo].[OrdenExamen] (NOLOCK) oe
					INNER JOIN[labo].[Orden] (NOLOCK) ord on oe.IdOrden = ord.IdOrden
					INNER JOIN[labo].[OrdenPaciente](NOLOCK) opa on ord.IdOrden = opa.IdOrden
					INNER JOIN[labo].[Paciente] (NOLOCK) pac on opa.IdPaciente = pac.IdPaciente
					INNER JOIN[conf].[Persona] (NOLOCK) per on pac.IdPersona = per.IdPersona
					INNER JOIN[conf].[Examen] (NOLOCK) exa on oe.IdExamen = exa.IdExamen
					WHERE
					(@valor IS  NULL OR ord.NroOrden = @valor OR UPPER(per.ApePaterno+per.ApeMaterno+ per.Nombre) LIKE '%'+UPPER(@valor)+'%' OR per.NroDocumento = @valor) AND
					(@fechaInicio IS NULL OR CONVERT(date, ord.FechaOrden) >= CONVERT(date, @fechaInicio)) AND
					(@fechaFin IS NULL OR CONVERT(date,ord.FechaOrden) <= CONVERT(date, @fechaFin))
				END";
    }
}
