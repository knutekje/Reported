

using Microsoft.AspNetCore.Mvc;
using Reported.Model.Report;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase{
    private readonly ReportedContext _context;

    public ReportController(ReportedContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ICollection<Report> Get()
    {
        return _context.Reports.ToList();
    }




}