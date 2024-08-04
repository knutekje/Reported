

using System.ComponentModel.DataAnnotations.Schema;

public class Item(){
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required long Id { get; set; }
    public required String ExternalId { get; set; }
    public required String Name { get; set; }
    public required Decimal Price {get; set;}
    public required String Unit  {get; set;}
    public VerifiedReport VerifiedReport {get; set;}
}
