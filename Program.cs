using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authentication.Cookies;

using Reported.Data;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.CookiePolicy;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddAuthorization();

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ReportedContext>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
           
         
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy 
            .WithOrigins("http://localhost:3000",
                            "https://localhost:3000",
                            "http://localhost:8000",
                            "http://debstar:8000",
                            "http://195.181.150.26:8000"
                            )

            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
            
      });
});




builder.Services.AddDbContext<ReportedContext>(options =>
    options.UseNpgsql("Host=192.168.0.107;Database=reporteddb;Username=reported;Password=KlU91Xp"));
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ReportedContext>();

    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapIdentityApi<IdentityUser>();


app.UseHttpsRedirection();





app.UseRouting(); 
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.UseCookiePolicy(new()
{   
    
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
    MinimumSameSitePolicy = SameSiteMode.None,
});

           

app.Run();

public class LogActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        Console.WriteLine($"Request method: {request.Method}");
        base.OnActionExecuting(context);
    }
};