namespace Persistence.Database.Procedimientos
{
    public class Reporte_BuscarPaciente
    {
        public string SP_Reporte_BuscarPaciente { get; } =
            @"CREATE OR ALTER PROCEDURE   [rpt].[Reporte_BuscarPaciente]
				@valor VARCHAR(50)			
				AS
				BEGIN
					SELECT per.NroDocumento, per.ApePaterno+' '+per.ApeMaterno+' '+per.Nombre NombreCompleto, per.IdPersona
					FROM [labo].[Orden] (NOLOCK) ord
					INNER JOIN[labo].[OrdenPaciente](NOLOCK) opa on ord.IdOrden = opa.IdOrden
					INNER JOIN[labo].[Paciente] (NOLOCK) pac on opa.IdPaciente = pac.IdPaciente
					INNER JOIN conf.Persona (NOLOCK) per on pac.IdPersona = per.IdPersona
					WHERE
					per.IdPersona!='01HTFSVCJC0PFRQAWGW634W6XM'AND
					(@valor IS  NULL OR UPPER(per.ApePaterno+per.ApeMaterno+ per.Nombre) LIKE '%'+UPPER(@valor)+'%' OR per.NroDocumento = @valor)
					GROUP BY per.NroDocumento, per.ApePaterno+' '+per.ApeMaterno+' '+per.Nombre, per.IdPersona
				END";
    }
}
