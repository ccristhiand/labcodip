using AspNetCore.Reporting;
using Common.Utility;
using Microsoft.AspNetCore.Mvc;
using Report.Service.Queries;
using Report.Service.Queries.Query;

namespace Report.Api.Controllers
{
    [ApiController]
    [Route(Routes.Etiqueta)]
    public class EtiquetaController : BaseController
    {
        private readonly IEtiquetaQueryService _etiquetaQueryService;
        private IWebHostEnvironment _webHostEnvironment;

        public EtiquetaController(IEtiquetaQueryService etiquetaQueryService, IWebHostEnvironment webHostEnvironment)
        {
            _etiquetaQueryService = etiquetaQueryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("imprimir")]
        public async Task<IActionResult> Imprimir(RequestReport request)
        {
            ResponseReport responseReport = new ResponseReport();

            List<EtiquetaQuery> model = new List<EtiquetaQuery>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            string usuario = CurrentUser.usuario;
            var result = await _etiquetaQueryService.Imprimir(request, usuario,"");

            model = result;

            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\EtiquetaArchitect.rdlc";


            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("Etiqueta", model);

            var reporte = localReport.Execute(RenderType.Pdf, 1, parameters, "");


            string base64 = Convert.ToBase64String(reporte.MainStream);

            responseReport.data = base64;

            return Ok(responseReport);
        }

    }
}
