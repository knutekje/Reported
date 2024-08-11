

using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Reported.Data;
using Reported.Model.Report;


[ApiController]
[Route("report/[controller]")]
[Authorize]
public class ReportController : ControllerBase{
    private readonly ReportedContext _context;

    public ReportController(ReportedContext context)
    {
        _context = context;
    }
    
    [HttpGet("/get")]
    public ICollection<Report> Get()
    {
        
        return _context.Reports.ToList();

    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Report>>  GetReport (int id)
     
    {
        var report = await _context.Reports.FindAsync(id);
        if (report == null)
        {
            return NotFound();
        }
        return report;


    }




    [HttpPost("/add")]
    public async Task<String> AddReport  (Report report){
       
        using (var memoryStream = new MemoryStream())
            {
                await report.MyFile.CopyToAsync(memoryStream);
                report.Image = memoryStream.ToArray();
            }
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();
        return "report added";
    }

    [HttpDelete("/delete")]
    public string DeleteReport (long id){
        Report report = _context.Reports.Find(id);
        _context.Reports.Remove(report);
        return "Report deleted";
    }

    [HttpPut("/update")]
    public string UpdateReport (Report report){
        _context.Reports.Update(report);
        return "Report updated";
    }




}