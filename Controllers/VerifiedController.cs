using Microsoft.AspNetCore.Mvc;
using Reported.Model.Report;



[ApiController]
[Route("[controller]")]
public class VerifiedController : ControllerBase{
    private readonly ReportedContext _context;
    public VerifiedController(ReportedContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ICollection<VerifiedReport> Get()
    {
        return _context.VerifiedReports.ToList();
    }



    /* Logic for retrieving report by id, transfering 
    fields to verifiedreport, deleting report and and picture*/
    [HttpPost]
    public string VerifyReport(int ReportId, VerifiedReport verifiedReport){
        Report report = _context.Reports.Find(ReportId);
        verifiedReport.ReportedTime = report.Date;
        verifiedReport.ProcessedTime = DateTime.Now;    
        return "Report verified";
        
    }


}