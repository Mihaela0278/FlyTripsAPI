using FlyTrips.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyTripsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfExportController : ControllerBase
    {
        private readonly IPdfReport _pdfReport;

        public PdfExportController(IPdfReport pdfReport)
        {
            _pdfReport = pdfReport;
        }

        [HttpGet]
        public IActionResult Export()
        {
            _pdfReport.ExportPdf();
            return Ok("Reported successfully!");
        }
    }
}
