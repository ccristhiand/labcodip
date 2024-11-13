IF OBJECT_ID('[rpt].[Reporte_ListaOrdenPorPaciente]','P') IS NOT NULL
BEGIN
   DROP PROCEDURE [rpt].[Reporte_ListaOrdenPorPaciente]
END
GO
	CREATE PROCEDURE [rpt].[Reporte_ListaOrdenPorPaciente]
	AS
	BEGIN
		SELECT ord.NroOrden, per.IdTipoDocu TipoDocumento, per.NroDocumento, opa.HistoriaClinica,
		per.ApePaterno, per.ApeMaterno, per.Nombre, exa.Abreviatura, exa.Nombre NombreExamen, oe.Resultado, exa.UnidadMedida, ord.FechaOrden, oe.FechaUsuarioValTec
		FROM[labo].[OrdenExamen] oe
		INNER JOIN[labo].[Orden] ord on oe.IdOrden = ord.IdOrden
		INNER JOIN[labo].[OrdenPaciente] opa on ord.IdOrden = opa.IdOrden
		INNER JOIN[labo].[Paciente] pac on opa.IdPaciente = pac.IdPaciente
		INNER JOIN[conf].[Persona] per on pac.IdPersona = per.IdPersona
		INNER JOIN[conf].[Examen] exa on oe.IdExamen = exa.IdExamen
	END
GO


IF OBJECT_ID('[rpt].[Reporte_ImprimirEtiqueta]','P') IS NOT NULL
BEGIN
   DROP PROCEDURE [rpt].[Reporte_ImprimirEtiqueta]
END
GO
	CREATE PROCEDURE [rpt].[Reporte_ImprimirEtiqueta] --'2' --1 --77756
	@IdeOrden VARCHAR(MAX),
	@TipMuestra	VARCHAR(100)=NULL,
	@Area VARCHAR(100)=NULL
	AS

	SELECT	DISTINCT O.IdOrden, O.NroOrden, 
			--O.NroOrden + '.'+ISNULL(TMUE.Dato1, '41') CodBarras, 
			O.Codigo Atencion, O.FechaOrden Fecha, PE.NroDocumento, OP.HistoriaClinica,
			ISNULL(PE.ApePaterno,'') + ' ' + ISNULL(PE.ApeMaterno,'') + ' ' + ISNULL(PE.Nombre,'') Nombres,
			PE.IdSexo, PE.FechaNacimiento FecNac, 
			--PE.EdadMostrar Edad, 
			--ISNULL(TMUE.Dato2,'PLASMA') Prueba, 		
					ISNULL (STUFF((
					SELECT ',' + EX2.Abreviatura
					 FROM [conf].[Examen] EX2  
					 WHERE EX2.IdExamen  IN (SELECT OE2.IdExamen  FROM [labo].[OrdenExamen] OE2 WHERE OE2.IdOrden=O.IdOrden)
				  FOR XML PATH ('')
			   ),1,1,'')
				,'')  Adicional1, 
			 ''Adicional2
	FROM	[labo].[Orden] O (NOLOCK)
			INNER JOIN [labo].[OrdenPaciente] OP (NOLOCK) ON O.IdOrden = OP.IdOrden
			INNER JOIN [labo].[Paciente] PA (NOLOCK) ON OP.IdPaciente =  PA.IdPaciente
			INNER JOIN [conf].[Persona] PE (NOLOCK) ON PA.IdPersona=PE.IdPersona
			INNER JOIN [labo].[OrdenExamen] OE (NOLOCK) ON O.IdOrden=OE.IdOrden AND OE.Estado='ACTI'
			INNER JOIN [conf].[Examen] E (NOLOCK) ON OE.IdExamen=E.IdExamen
	--WHERE	O.IdOrden in (select * from dbo.Split(@IdeOrden,',')) AND 
	--    E.Abreviatura LIKE CASE WHEN @Area IS NULL THEN '%%' ELSE '%'+@Area+'%'  END
GO


[rpt].[Reporte_ImprimirEtiqueta]