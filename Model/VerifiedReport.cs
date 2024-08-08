

using System.ComponentModel.DataAnnotations.Schema;

public class VerifiedReport (){

    [Column("id")]
    public int Id {get; set;}

    public required string Title { get; set; }

    public required DateTime ReportedTime {get; set;}

    public required DateTime ProcessedTime {get; set;}

    public required long ItemId {get; set;}

    public required String ReportedBy {get;set;}

    public string? Description { get; set; }
    public Decimal Value {get; set;}
    public Decimal Quantity {get; set;}

    public Item Item {get; set;}

}
   

