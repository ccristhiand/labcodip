namespace Persistence.Database.Procedimientos
{
    public class Reporte_BuscarResultadoPaciente
    {
        public string SP_Reporte_BuscarResultadoPaciente { get; } =
            @"CREATE OR ALTER  PROCEDURE [rpt].[Reporte_BuscarResultadoPaciente]
			@id VARCHAR(50)
			AS
			BEGIN
				SELECT exa.Abreviatura, oe.Resultado,oe.FechaResultado,exa.Color
				FROM[labo].[OrdenExamen] (NOLOCK) oe
				INNER JOIN[labo].[Orden] (NOLOCK) ord on oe.IdOrden = ord.IdOrden
				INNER JOIN[labo].[OrdenPaciente](NOLOCK) opa on ord.IdOrden = opa.IdOrden
				INNER JOIN[labo].[Paciente] (NOLOCK) pac on opa.IdPaciente = pac.IdPaciente
				INNER JOIN[conf].[Examen] (NOLOCK) exa on oe.IdExamen = exa.IdExamen
				WHERE
				pac.IdPersona = @id
			END";
    }
}
