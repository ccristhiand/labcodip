using Microsoft.AspNetCore.Mvc;
using Tracking.Service.Queries;

namespace Tracking.Api.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingQueryService _ITrackingQueryService;

        public TrackingController(ITrackingQueryService ITrackingQueryService)
        {
            _ITrackingQueryService = ITrackingQueryService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string? dateInit, string? dateFin, string? text, int page, int pages)
        {
            try
            {
                DateTime DateInitConvert = DateTime.Parse(dateInit);
                DateTime DateFinConvert = DateTime.Parse(dateFin);
                text = text ?? string.Empty;
                return Ok(await _ITrackingQueryService.GetTracking(DateInitConvert, DateFinConvert, text, page, pages));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
