using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
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
}
