using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpLogging;
using System.Net;
using Reported.Data;

using Microsoft.AspNetCore.Mvc.Filters;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddAntiforgery();


builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<ReportedContext>();



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
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
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();



           

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