namespace Persistence.Database.Procedimientos
{
    public class Tracking_Agregar
    {
        public string SP_Tracking_Agregar { get; } =
             @"CREATE OR ALTER PROC [trak].[Tracking_Agregar](
				 @IdOrden VARCHAR(MAX)
				,@IdTipoMuestra VARCHAR(MAX)
				,@UsuarioImpresionEtiqueta VARCHAR(30)
				)AS BEGIN
					IF EXISTS(SELECT 1 FROM [labo].[OrdenExamen] OE INNER JOIN  [labo].[Orden] O ON OE.IdOrden=O.IdOrden WHERE O.IdOrden IN(SELECT VALUE FROM STRING_SPLIT(@IdOrden,',')))
					BEGIN
						IF EXISTS(SELECT 1 FROM [trak].[Tracking] WHERE 
						IdOrden IN(SELECT VALUE FROM STRING_SPLIT(@IdOrden,',')) AND
						IdTipoMuestra IN(SELECT VALUE FROM STRING_SPLIT(@IdTipoMuestra,','))
						)

						BEGIN
							UPDATE [trak].[Tracking] SET FechaActualizacionImpresionEtiqueta =GETDATE() 
							WHERE IdOrden IN(SELECT VALUE FROM STRING_SPLIT(@IdOrden,',')) AND
									IdTipoMuestra IN(SELECT VALUE FROM STRING_SPLIT(@IdTipoMuestra,','))		
						END
						ELSE
							BEGIN
								INSERT INTO  [trak].[Tracking] 
								(
									 [IdOrden]
									,[NroOrden]
									,[IdTipoMuestra]
									,[IdOrdenExamen]
									,[IdExamen]
									,[DocumentoPaciente]
									,[NombrePaciente]
									,[ApellidoPaternoPaciente]
									,[ApellidoMaternoPaciente]
									,[EstadoImpresionEtiqueta]
									,[UsuarioImpresionEtiqueta]
									,[FechaImpresionEtiqueta]
			  
								)SELECT 
									 O.IdOrden
									,O.NroOrden
									,TM.IdTipoMuestra
									,OE.IdOrdenExamen
									,OE.IdExamen
									,P.NroDocumento
									,P.Nombre 
									,P.ApePaterno
									,P.ApePaterno
									,1
									,@UsuarioImpresionEtiqueta 
									,GETDATE()
								FROM [labo].[OrdenExamen] OE 
								INNER JOIN [labo].[Orden] O ON OE.IdOrden=O.IdOrden
								INNER JOIN [conf].[Examen] E ON OE.IdExamen=E.IdExamen 
								INNER JOIN [conf].[TipoMuestra] TM ON E.IdTipoMuestra=TM.IdTipoMuestra
								INNER JOIN [labo].[OrdenPaciente] OP ON OE.IdOrden=OP.IdOrden
								INNER JOIN [labo].[Paciente] PA ON OP.IdPaciente=PA.IdPaciente
								INNER JOIN [conf].[Persona] P ON PA.IdPersona=P.IdPersona
								WHERE OE.IdOrden IN(SELECT VALUE FROM STRING_SPLIT(@IdOrden,',')) AND TM.IdTipoMuestra IN (SELECT VALUE FROM STRING_SPLIT(@IdTipoMuestra,','))
							END	
						END
					END";

    }


}
