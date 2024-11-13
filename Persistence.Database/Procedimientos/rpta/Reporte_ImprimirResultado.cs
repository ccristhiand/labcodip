namespace Persistence.Database.Procedimientos
{
    public class Reporte_ImprimirResultado
    {
        public string SP_Reporte_ImprimirResultado { get; } =
            @"CREATE OR ALTER   PROCEDURE [rpt].[Reporte_ImprimirResultadoPaciente]
                @Id varchar(50)
                AS
                select 
                PE.ApePaterno+' '+PE.ApeMaterno+' '+PE.Nombre AS NombreCompleto,
                PE.NroDocumento,
                PE.FechaNacimiento,
                CAST(DATEDIFF(YEAR, PE.FechaNacimiento, OD.FechaOrden) AS VARCHAR(3)) + ' años' AS Edad,
                TA.Nombre AS Sexo,
                OD.FechaOrden,
                EX.Abreviatura AS Examen, 
                OE.Resultado, 
                EX.UnidadMedida,
                EX.RangoMostrar,
				OE.NombrePerfil AS NombrePerfil,
				AR.Nombre AS NombreArea,
                (select PM.ApePaterno+' '+PM.ApeMaterno+' '+PM.Nombre
                from [labo].[OrdenPaciente] OPM 
                inner join [labo].[Medico] ME ON OPM.IdMedico = ME.IdMedico
                inner join [conf].[Persona] PM ON ME.IdPersona = PM.IdPersona
                where OPM.IdOrden = OP.IdOrden)AS Medico,
				(select top 1 HO.Titulo from [conf].[Hospital] HO) Titulo
                from [labo].[OrdenExamen] OE 
                inner join [conf].[Examen] EX ON OE.IdExamen = EX.IdExamen
                inner join [labo].[Orden] OD ON OE.IdOrden = OD.IdOrden
                inner join [labo].[OrdenPaciente] OP ON OD.IdOrden= OP.IdOrden
                inner join [labo].[Paciente] PA ON OP.IdPaciente= PA.IdPaciente
                inner join [conf].[Persona] PE ON PA.IdPersona= PE.IdPersona
                inner join [conf].[TablaMaestra] TA ON PE.IdSexo= TA.Codigo 
				inner join [conf].[Area] AR ON OE.IdArea = AR.IdArea
                where TA.Tabla='Sexo' AND OE.IdOrden=@Id
			";
    }
}
