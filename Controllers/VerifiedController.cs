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
    public async Task<string> VerifyReportAsync(VerifiedReport verifiedReport){
        

        /*
        public int Id { get; set; }  
        public required string Title { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public IFormFile? MyFile { get; set; }
        public byte[]? Image { get; set;}
        public required DateTime Date { get; set; }
        public required String ReportedBy {get;set;}*/

        /* 
        public int Id {get; set;}
        public required string Title { get; set; }
        public required DateTime ReportedTime {get; set;}
        public required DateTime ProcessedTime {get; set;}
        public required long ItemId {get; set;}
        public required String ReportedBy {get;set;}
        public string? Description { get; set; }
        public Item Item {get; set;}
        */
        
        var report = await _context.Reports.FindAsync(verifiedReport.Id);
        _ = _context.Reports.Remove(report);
        _context.VerifiedReports.Add(verifiedReport);
        await _context.SaveChangesAsync();


            


        return "Report verified";
        
    }


}