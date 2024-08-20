using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reported.Data;


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
 /*   [HttpGet("/get")]
    public string Getsomething(){
        return "HORSE  AND SHIT";
    }*/

}
