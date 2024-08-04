

public class Item(){
    public long Id { get; set; }
    public int ExternalId { get; set; }
    public required String Name { get; set; }
    public required String Description { get; set; }
    public required Decimal Price {get; set;}
    public required String unit {get; set;}
    public VerifiedReport VerifiedReport {get; set;}
}
