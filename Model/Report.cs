
namespace Reported.Model.Report;


public class Report (){
    
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required byte[] Image { get; set; }
    public required DateTime Date { get; set; }
    public required String ReportedBy {get;set;}

}