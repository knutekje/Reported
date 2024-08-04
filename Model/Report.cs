
using System.ComponentModel.DataAnnotations.Schema;

namespace Reported.Model.Report;


public class Report (){
    
    public int Id { get; set; }  
    public required string Title { get; set; }
    public string? Description { get; set; }

    [NotMapped]
    public IFormFile? MyFile { get; set; }

    public byte[]? Image { get; set;}
       
    public required DateTime Date { get; set; }
    public required String ReportedBy {get;set;}

}