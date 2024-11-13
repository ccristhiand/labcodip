namespace Persistence.Database.Procedimientos
{
    public class Reporte_ImprimirEtiqueta
    {
        public string SP_Reporte_ImprimirEtiqueta { get; } =
            @"CREATE OR ALTER PROCEDURE [rpt].[Reporte_ImprimirEtiqueta]
				@IdOrden VARCHAR(MAX),
				@IdTipoMuestra VARCHAR(MAX)=NULL,
				@Usuario VARCHAR(40)=NULL
				AS BEGIN
				SELECT	DISTINCT O.IdOrden, O.NroOrden, 
						O.NroOrden + '.'+ISNULL(TM.CodigoTipoMuestra,'') CodMuestra, 
						O.Codigo Atencion, O.FechaOrden Fecha, PE.NroDocumento, OP.HistoriaClinica,
						ISNULL(PE.ApePaterno,'') + ' ' + ISNULL(PE.ApeMaterno,'') + ' ' + ISNULL(PE.Nombre,'') Nombres,
						PE.IdSexo Sexo, PE.FechaNacimiento FecNac, ISNULL(TM.Nombre,'') Prueba, 		
								ISNULL (STUFF((
								SELECT ',' + EX2.Abreviatura
								 FROM [conf].[Examen] EX2  
								 WHERE EX2.IdExamen  IN (SELECT OE2.IdExamen  FROM [labo].[OrdenExamen] OE2 WHERE OE2.IdOrden=O.IdOrden)
							  FOR XML PATH ('')
						   ),1,1,'')
							,'')  Examen
						FROM	[labo].[Orden] O (NOLOCK)
						INNER JOIN [labo].[OrdenPaciente] OP (NOLOCK) ON O.IdOrden = OP.IdOrden
						INNER JOIN [labo].[Paciente] PA (NOLOCK) ON OP.IdPaciente =  PA.IdPaciente
						INNER JOIN [conf].[Persona] PE (NOLOCK) ON PA.IdPersona=PE.IdPersona
						INNER JOIN [labo].[OrdenExamen] OE (NOLOCK) ON O.IdOrden=OE.IdOrden
						INNER JOIN [conf].[Examen] E (NOLOCK) ON OE.IdExamen=E.IdExamen
						INNER JOIN [conf].[TipoMuestra] TM (NOLOCK) ON E.IdTipoMuestra = TM.IdTipoMuestra
				WHERE    O.IdOrden  IN(SELECT VALUE FROM STRING_SPLIT(@IdOrden,','))  AND TM.IdTipoMuestra IN (SELECT VALUE FROM STRING_SPLIT(@IdTipoMuestra,','))


			 Exec [trak].[Tracking_Agregar] @IdOrden,@IdTipoMuestra,@Usuario

			END

			";
    }
}
