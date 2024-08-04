using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase{
    private readonly ReportedContext _context;
    public ItemsController(ReportedContext context)
    {
        _context = context;
    }

    
    [HttpGet]
    public ICollection<Item> Get()
    {
        return _context.Items.ToList();
    }
}