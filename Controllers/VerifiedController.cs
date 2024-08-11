using Microsoft.AspNetCore.Mvc;
using Reported.Model.Report;
using Reported.Data;


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
    public async Task<string> VerifyReportAsync(VerifiedReport verifiedReport){
        
        
        var report = await _context.Reports.FindAsync(verifiedReport.Id);
        _ = _context.Reports.Remove(report);
        _context.VerifiedReports.Add(verifiedReport);
        await _context.SaveChangesAsync();


            


        return "Report verified";
        
    }


}