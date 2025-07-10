using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ReportService.Models;
using ReportService.Services; // Required for ReportMongoService

namespace ReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportMongoService _reportService;

        public ReportController(ReportMongoService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Report report)
        {
            await _reportService.CreateReport(report);
            Console.WriteLine($"EVENT: report.created -> {report.Title}");
            return Ok(new { message = "Report created", report });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _reportService.GetReports();
            return Ok(reports);
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new { message = "pong", timestamp = DateTime.UtcNow });
        }
    }
}
