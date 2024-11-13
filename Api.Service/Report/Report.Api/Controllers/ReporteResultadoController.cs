using AspNetCore.Reporting;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Report.Service.Queries;

namespace Report.Api.Controllers
{
    [ApiController]
    [Route(Routes.Reporte)]
    public class ReporteResultadoController : ControllerBase
    {
        private readonly IReporteResultadoQueryService _reporteQueryService;
        private IWebHostEnvironment _webHostEnvironment;

        public ReporteResultadoController(IReporteResultadoQueryService reporteQueryService, IWebHostEnvironment webHostEnvironment)
        {
            _reporteQueryService = reporteQueryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("resultadoPaciente")]
        public async Task<IActionResult> resultadoPaciente(string? id)
        {
            ResponseReport responseReport = new ResponseReport();

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var response = await _reporteQueryService.GetResultadoPaciente(id);

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\ResultadoPaciente.rdlc";


            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("ResultadoPaciente", response);

            var reporte = localReport.Execute(RenderType.Pdf, 1, parameters, "");

            string base64 = Convert.ToBase64String(reporte.MainStream);

            responseReport.data = base64;

            return Ok(responseReport);
        }
    }
}
