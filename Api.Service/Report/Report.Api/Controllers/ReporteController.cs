using ClosedXML.Excel;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Report.Service.Queries;
using Report.Service.Queries.Query;

namespace Report.Api.Controllers
{
    [ApiController]
    [Route(Routes.Reporte)]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteGraficoQueryService _reporteQueryService;

        public ReporteController(IReporteGraficoQueryService reporteQueryService)
        {
            _reporteQueryService = reporteQueryService;
        }

        [HttpPost("getOrdenPaciente")]
        public async Task<IActionResult> GetOrdenPaciente(RequestReport request)
        {
            var result = await _reporteQueryService.GetOrdenPaciente(request);

            return Ok(result);
        }

        [HttpGet("getPaciente")]
        public async Task<IActionResult> GetPaciente(string? valor)
        {
            var result = await _reporteQueryService.GetPaciente(valor);

            return Ok(result);
        }

        [HttpGet("getResultadoPaciente")]
        public async Task<IActionResult> GetResultadoPaciente(string? id)
        {
            var result = await _reporteQueryService.GetResultadoPaciente(id);

            return Ok(result);
        }


        [HttpPost("exportar")]
        public async Task<IActionResult> Exportar(RequestReport request)
        {
            ResponseReport responseReport = new ResponseReport();

            var result = await _reporteQueryService.Exportar(request);

            string NomFile = "RptOrdenPorPaciente" + DateTime.Now.ToString("yyyymmddhhmmss") + ".xlsx";
            string nomSheet = DateTime.Now.ToString("ddMMyyyy");


            var workbook = new XLWorkbook();
            var worksheet = workbook.AddWorksheet(nomSheet);


            //AGREGAR FORMATO
            headerOrdenPorPaciente(worksheet);

            //AGREGO LOS DATOS DE LA HOJA
            bodtOrdenPorPaciente(worksheet, result);

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                string base64 = Convert.ToBase64String(content);

                responseReport.data = base64;
                responseReport.name = NomFile;

                return Ok(responseReport);
            }
        }

        private void headerOrdenPorPaciente(IXLWorksheet worksheet)
        {
            //TITULO DE LA HOJA
            worksheet.Range("A1:N1").Merge().Value = "REPORTE ORDEN POR PACIENTE";

            //FORMATO DE TITULO Y SUBTITULO
            worksheet.Range("A1:N2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Range("A1:N2").Style.Font.FontColor = XLColor.FromArgb(0x055196);
            worksheet.Range("A1:N2").Style.Font.Bold = true;

            worksheet.Range("A1:N1").Style.Font.FontSize = 16;

            //FORMATO ENCABEZADO DE LA TABLA
            worksheet.Range("A3:E3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Range("F3:G3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            worksheet.Range("H3:H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Range("I3:K3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            worksheet.Range("A3:K3").Style.Font.FontColor = XLColor.FromArgb(0x055196);
            worksheet.Range("A3:K3").Style.Font.Bold = true;
            worksheet.Range("A3:K3").Style.Font.FontSize = 10;

            worksheet.Column("A").Width = 10;//Nro Orden
            worksheet.Column("B").Width = 15;//Tipo Documento
            worksheet.Column("C").Width = 15;//Nro Documento
            worksheet.Column("D").Width = 15;//Historia Clinica
            worksheet.Column("E").Width = 30;//Paciente
            worksheet.Column("F").Width = 15;//Abreviatura
            worksheet.Column("G").Width = 20;//Nombre Examen
            worksheet.Column("H").Width = 20;//Resultado
            worksheet.Column("I").Width = 20;//Unidad Medida
            worksheet.Column("J").Width = 20;//Fecha Orden
            worksheet.Column("K").Width = 20;//Fecha Validacion


            //FORMATO CUERPO
            worksheet.Range("A4:E4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Range("F4:G4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            worksheet.Range("H4:H4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            worksheet.Range("I4:K4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

            //AGREGO EL ENCABEZADO DE LA HOJA
            worksheet.Cell("A3").Value = "Nro Orden";
            worksheet.Cell("B3").Value = "Tipo Documento";
            worksheet.Cell("C3").Value = "Nro Documento";
            worksheet.Cell("D3").Value = "Historia Clinica";
            worksheet.Cell("E3").Value = "Paciente";
            worksheet.Cell("F3").Value = "Abreviatura";
            worksheet.Cell("G3").Value = "Nombre Examen";
            worksheet.Cell("H3").Value = "Resultado";
            worksheet.Cell("I3").Value = "Unidad Medida";
            worksheet.Cell("J3").Value = "Fecha Orden";
            worksheet.Cell("K3").Value = "Fecha Validacion";
        }

        private void bodtOrdenPorPaciente(IXLWorksheet worksheet, List<OrdenPorPacienteQuery> dt)
        {
            int celda2 = 4;

            dt.ForEach(row =>
            {
                var fila1 = "A" + celda2 + ":" + "k" + celda2;

                worksheet.Cell("A" + celda2).Value = (row.NroOrden == null) ? "" : row.NroOrden!.ToString();
                worksheet.Cell("B" + celda2).Value = (row.TipoDocumento == null) ? "" : row.TipoDocumento!.ToString();
                worksheet.Cell("C" + celda2).Value = (row.NroDocumento == null) ? "" : row.NroDocumento!.ToString();
                worksheet.Cell("D" + celda2).Value = (row.HistoriaClinica == null) ? "" : row.HistoriaClinica!.ToString();
                worksheet.Cell("E" + celda2).Value = (row.NombreCompleto == null) ? "" : row.NombreCompleto!.ToString();
                worksheet.Cell("F" + celda2).Value = (row.Abreviatura == null) ? "" : row.Abreviatura!.ToString();
                worksheet.Cell("G" + celda2).Value = (row.NombreExamen == null) ? "" : row.NombreExamen!.ToString();
                worksheet.Cell("H" + celda2).Value = (row.Resultado == null) ? "" : row.Resultado!.ToString();
                worksheet.Cell("I" + celda2).Value = (row.UnidadMedida == null) ? "" : row.UnidadMedida!.ToString();
                worksheet.Cell("J" + celda2).Value = (row.FechaOrden == null) ? "" : row.FechaOrden!.ToString();
                worksheet.Cell("K" + celda2).Value = (row.FechaUsuarioValMed == null) ? "" : row.FechaUsuarioValMed!.ToString();

                worksheet.Range(fila1).Style.Font.FontColor = XLColor.FromArgb(0x2875C1);

                if ((celda2 % 2) == 0)
                {
                    worksheet.Range(fila1).Style.Fill.BackgroundColor = XLColor.FromArgb(0xDEEDFC);
                }

                celda2 = celda2 + 1;
            });

        }

    }
}
